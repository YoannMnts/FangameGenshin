using System.Threading;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Managers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Project.Gameplay.Scripts.Roads
{
    public class RoadLoader
    {
        private readonly RoadMapper roadMapper = new();

        public async Awaitable<Road> LoadAsync(string key, CancellationToken ct)
        {
            var handle = Addressables.LoadAssetAsync<RoadDataBase>(key);

            await handle.Task;
    
            ct.ThrowIfCancellationRequested();

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Addressables.Release(handle);
                Debug.LogError($"Failed to load road: {key}");
                return null;
            }

            var runtime = roadMapper.Map(handle.Result);
            Addressables.Release(handle);

            return runtime;
        }
    }
}