using System;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Core.Scripts.Datas;
using Project.Gameplay.Scripts.GameplayPhases.Routes;
using Project.Gameplay.Scripts.Mappers;
using Project.Gameplay.Scripts.Storage;
using UnityEngine;

namespace Project.Gameplay.Scripts
{
    public class GameManager : IDisposable
    {
        private readonly Storage<Guid> routeIdStorage;
        private readonly Loader<RouteData, Route> routeLoader;
        private readonly CancellationToken ct;

        public GameManager(CancellationToken ct)
        {
            routeIdStorage = new Storage<Guid>();
            routeLoader = new Loader<RouteData, Route>();
            this.ct = ct;
        }
        
        public async Awaitable LaunchRoute(RouteData data)
        {
            var guid = data.ID;
            var route = await routeLoader.LoadAsync<RouteMapper>(guid, ct);

            if (Equals(route, Route.Empty))
            {
                Debug.LogError($"Failed to load route: {guid.ToString()}");
                return;
            }
            
            var routePhase = new RoutePhase(route, routeIdStorage);
            var result = await routePhase.Run();
            
            if(result.value)
                routeIdStorage.Store(data.ID);
        }
        
        public void Dispose()
        {
            routeIdStorage?.Dispose();
        }
    }
}