using System;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.GameplayPhases.Routes;
using Project.Gameplay.Scripts.GameplayPhases.Talks;
using Project.Gameplay.Scripts.Mappers;
using Project.Gameplay.Scripts.Storage;
using UnityEngine;

namespace Project.Gameplay.Scripts
{
    public class GameManager : IDisposable
    {
        public bool RouteHasBeenDone => RouteDoneStorage.Contains(currentRoute);
        public DataStorage<RouteData, Route> RouteDoneStorage { get; private set; }
        public DataStorage<TalkData, Talk> TalkHistoric { get; private set; }
        
        
        private readonly CancellationToken ct;
        
        private Route currentRoute;

        public GameManager(CancellationToken ct)
        {
            RouteDoneStorage = new ();
            this.ct = ct;
        }
        
        public async Awaitable LaunchRoute(RouteData data)
        {
            if(MapperBucket<RouteData, Route>.TryGet(out var mapper))
            {
                currentRoute = await mapper.Map(data, ct);
            }

            if (currentRoute == null)
            {
                Debug.LogError($"Failed to load route: {data.ID.ToString()}");
                return;
            }
            
            TalkHistoric = new ();
            
            var routePhase = new RoutePhase(currentRoute, this);
            var result = await routePhase.Run();
            
            if(result.value)
                RouteDoneStorage.Store(data);
            
            TalkHistoric.Dispose();
        }
        
        public void Dispose()
        {
            RouteDoneStorage?.Dispose();
            TalkHistoric?.Dispose();
        }
    }
}