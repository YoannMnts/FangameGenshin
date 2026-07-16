using System;
using Project.Core.Scripts.Datas;
using Project.Gameplay.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Debugs
{
    public class GameManagerMono : MonoBehaviour
    {
        private GameManager gameManager;

        private void Awake()
        {
            gameManager = new GameManager(destroyCancellationToken);
        }

        private void OnDestroy()
        {
            gameManager?.Dispose();
        }

        [Button]
        public void LaunchRoute(RouteData routeData)
        {
            _ = gameManager.LaunchRoute(routeData);
        }
    }
}