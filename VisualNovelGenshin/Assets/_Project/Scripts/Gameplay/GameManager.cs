using System;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Core.Scripts.Datas;
using Project.Gameplay.Scripts.Mappers;
using Project.Gameplay.Scripts.Routes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Gameplay.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private readonly Loader<RouteData, Route> routeLoader = new();
        private CancellationToken ct;
        
        private async Awaitable LaunchRoute(Guid guid)
        {
            var route = await routeLoader.LoadAsync<RouteMapper>(guid, ct);

            if (route == null)
            {
                Debug.LogError($"Failed to load route: {guid.ToString()}");
                return;
            }

            var routePhase = new RoutePhase(route);
            var result = await routePhase.Run();
            
            Debug.Log($"Route Phase result: {result.value}");
            if(result.value)
                RouteManager.AddRouteDone(route);
            
        }

        [Button]
        public void LaunchRoute(RouteData route)
        {
            _ = LaunchRoute(route.ID);
        }
    }
}