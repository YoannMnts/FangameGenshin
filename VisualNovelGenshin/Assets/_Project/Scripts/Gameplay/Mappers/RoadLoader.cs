using System.Threading;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Roads;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Project.Gameplay.Scripts.Mappers
{
    public class RoadLoader : ILoader<RoadData, Road>
    {
        private readonly RoadMapper mapper = new RoadMapper();
        public async Awaitable<Road> LoadAsync(string key, CancellationToken ct)
        {
            var handle = Addressables.LoadAssetAsync<RoadData>(key);

            await handle.Task;
    
            ct.ThrowIfCancellationRequested();

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Addressables.Release(handle);
                Debug.LogError($"Failed to load dialogue: {key}");
                return null;
            }

            var runtime = await mapper.MapAsync(handle.Result, ct);
            Addressables.Release(handle);

            return runtime;
        }
    }
}