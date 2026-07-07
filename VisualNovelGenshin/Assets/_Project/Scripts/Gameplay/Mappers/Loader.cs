using System.Threading;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Project.Gameplay.Scripts.Mappers
{
    /*
    public abstract class Loader<TData, TRuntime> : ILoader<TData, TRuntime>
    where TData : IData
    where TRuntime : IRuntime
    {
        public virtual async Awaitable<TRuntime> LoadAsync<TMapper>(string key, TMapper mapper, CancellationToken ct) 
            where TMapper : IMapper<TData, TRuntime>
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

            var runtime = await mapper.Map(handle.Result, ct);
            Addressables.Release(handle);

            return runtime;
        }
    }
    */
}