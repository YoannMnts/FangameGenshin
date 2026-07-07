using System;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Core.Scripts.Datas;
using Project.Gameplay.Scripts.Mappers;
using Project.Gameplay.Scripts.Roads;
using UnityEngine;

namespace Project.Gameplay.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private readonly RoadLoader roadLoader = new();
        private CancellationToken ct;

        [Header("Debug")] 
        [SerializeField] 
        private RoadData roadToLaunch;

        private async void Start()
        {
            try
            {
                await LaunchRoad(roadToLaunch.ID.ToString());
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        private async Awaitable LaunchRoad(string key)
        {
            var road = await roadLoader.LoadAsync(key, ct);

            if (road == null)
            {
                Debug.LogError($"Failed to load road: {key}");
                return;
            }

            var dialoguePhase = new RoadPhase(road);
            dialoguePhase.RunAndForget();
        }
    }
}