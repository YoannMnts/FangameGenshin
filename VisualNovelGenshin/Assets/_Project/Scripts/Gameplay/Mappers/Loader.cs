using System;
using System.Threading;
using Project.Core.Scripts.Mappers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Project.Gameplay.Scripts.Mappers
{
    public class Loader<TData, TRuntime> : ILoader<TData, TRuntime>
        where TData : IData
        where TRuntime : IRuntime
    {
        public async Awaitable<TRuntime> LoadAsync<TMapper>(Guid key, CancellationToken ct) 
            where TMapper : IMapper<TData, TRuntime>, new()
        {
            var result = await LoadAsync<TMapper>(key.ToString(), ct);
            return result;
        }
        
        public async Awaitable<TRuntime> LoadAsync<TMapper>(string key, CancellationToken ct) 
            where TMapper : IMapper<TData, TRuntime>, new()
        {
            var mapper = new TMapper();
            var handle = Addressables.LoadAssetAsync<TData>(key);

            await handle.Task;
    
            ct.ThrowIfCancellationRequested();

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Addressables.Release(handle);
                Debug.LogError($"Failed to load dialogue: {key}");
                return default;
            }

            var runtime = await mapper.Map(handle.Result, ct);
            Addressables.Release(handle);

            return runtime;
        }
    }
}