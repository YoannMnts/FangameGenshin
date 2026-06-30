using System;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Gameplay.Scripts.Roads;
using UnityEngine;

namespace Project.Gameplay.Scripts
{
    public class GameManager
    {
        private readonly RoadLoader loader = new();
        private Road currentRoad;
        
        private CancellationToken ct;

        private async void Start()
        {
            try
            {
                await LoadRoad("Roads/Route1");
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        private async Awaitable LoadRoad(string key)
        {
            currentRoad = await loader.LoadAsync(key, ct);

            if (currentRoad == null)
            {
                Debug.LogError($"Failed to load road: {key}");
                return;
            }

            var roadPhase = new RoadPhase(currentRoad);
            roadPhase.RunAndForget();
        }
    }
}