using System;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Core.Scripts.Datas;
using Project.Gameplay.Scripts.GameplayPhases.Routes;
using Project.Gameplay.Scripts.GameplayPhases.Talks;
using Project.Gameplay.Scripts.Mappers;
using Project.Gameplay.Scripts.Storage;
using UnityEngine;

namespace Project.Gameplay.Scripts
{
    public class GameManager : IDisposable
    {
        public readonly DataStorage<RouteData> routeStorage;
        public readonly DataStorage<TalkData> talkHistoric;
        
        private readonly Loader<RouteData> routeLoader;
        private readonly RouteMapper routeMapper;
        
        private readonly CancellationToken ct;

        public GameManager(CancellationToken ct)
        {
            routeStorage = new ();
            talkHistoric = new ();
            routeLoader = new ();
            routeMapper = new ();
            this.ct = ct;
        }
        
        public async Awaitable LaunchRoute(RouteData data)
        {
            var guid = data.ID;
            var routeData = await routeLoader.LoadAsync(guid, ct);
            var route = await routeMapper.Map(routeData, ct);

            if (route == null)
            {
                Debug.LogError($"Failed to load route: {guid.ToString()}");
                return;
            }
            
            var routePhase = new RoutePhase(route, this);
            var result = await routePhase.Run();
            
            if(result.value)
                routeStorage.Store(data);
        }
        
        public void Dispose()
        {
            routeStorage?.Dispose();
        }
    }
}