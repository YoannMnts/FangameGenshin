using System;
using System.Threading;
using Project.Core.Scripts.Mappers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Project.Gameplay.Scripts.Mappers
{
    public class Loader<TData> : ILoader<TData>
        where TData : IData
    { 
        public async Awaitable<TData> LoadAsync(Guid guid, CancellationToken ct = default)
        {
            var key = guid.ToString();
            var handle = Addressables.LoadAssetAsync<TData>(key);
            
            await handle.Task;

            ct.ThrowIfCancellationRequested();

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Addressables.Release(handle);
                Debug.LogError($"Failed to load dialogue: {key}");
                return default;
            }

            var data = handle.Result;
            Addressables.Release(handle);
            
            return data;
        }
    }
}