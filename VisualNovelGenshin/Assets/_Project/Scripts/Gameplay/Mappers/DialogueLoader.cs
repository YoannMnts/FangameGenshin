using System.Threading;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Dialogues;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Project.Gameplay.Scripts.Mappers
{
    public class DialogueLoader : ILoader<DialogueData, Dialogue>
    {
        private readonly DialogueMapper mapper = new DialogueMapper();

        public async Awaitable<Dialogue> LoadAsync(string key, CancellationToken ct)
        {
            var handle = Addressables.LoadAssetAsync<DialogueData>(key);

            await handle.Task;
    
            ct.ThrowIfCancellationRequested();

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Addressables.Release(handle);
                Debug.LogError($"Failed to load dialogue: {key}");
                return null;
            }

            var runtime = mapper.Map(handle.Result);
            Addressables.Release(handle);

            return runtime;
        }
    }
}