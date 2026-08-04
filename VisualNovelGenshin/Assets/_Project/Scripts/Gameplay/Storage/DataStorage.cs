using System;
using System.Collections.Generic;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Mappers;
using UnityEngine;
using UnityEngine.Pool;

namespace Project.Gameplay.Scripts.Storage
{
    public class DataStorage<TData> : IDisposable where TData : ScriptableData, IData
    {
        private readonly HashSet<Guid> historic = HashSetPool<Guid>.Get();
        private readonly Loader<TData> loader;

        public void Store(TData value) 
            => historic.Add(value.ID);
        
        public void Remove(TData value) 
            => historic.Remove(value.ID);

        public bool Contains(TData value) 
            => historic.Contains(value.ID);

        public IEnumerable<TBehaviour> GetBehaviours<TBehaviour>() where TBehaviour : IBehaviour<TData>
        {
            var list = new List<TBehaviour>();
            _ = GetBehaviours(list);
            return list;
        }
        
        public async Awaitable GetBehaviours<TBehaviour>(List<TBehaviour> list) where TBehaviour : IBehaviour<TData>
        {
            foreach (var key in historic)
            {
                var data = await loader.LoadAsync(key);
                if (!MapperBucket<TData, TBehaviour>.TryGet(out var mapper)) 
                    continue;
                
                var behaviour = await mapper.Map(data);
                list.Add(behaviour);
            }
        }

        public void Dispose() 
            => HashSetPool<Guid>.Release(historic);
    }
}