using System;
using System.Collections.Generic;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using UnityEngine;
using UnityEngine.Pool;

namespace Project.Gameplay.Scripts.Storage
{
    public class DataStorage<TData, TBehaviour> : IDisposable 
        where TData : ScriptableData, IData
        where TBehaviour : IBehaviour<TData>
    {
        private readonly HashSet<Guid> historic = HashSetPool<Guid>.Get();

        public void Store(TBehaviour behaviour)
            => historic.Add(behaviour.ID);
        
        public void Store(TData value) 
            => historic.Add(value.ID);
        
        public void Remove(TBehaviour behaviour)
            => historic.Remove(behaviour.ID);
        
        public void Remove(TData value) 
            => historic.Remove(value.ID);

        public bool Contains(TBehaviour behaviour)
            => historic.Contains(behaviour.ID);
        
        public bool Contains(TData value) 
            => historic.Contains(value.ID);

        public IEnumerable<TBehaviour> GetBehaviours()
        {
            using (ListPool<TBehaviour>.Get(out var list))
            {
                _ = GetBehaviours(list);
                return list.ToArray();
            }
        }
        
        public async Awaitable GetBehaviours(List<TBehaviour> list) 
        {
            foreach (var guid in historic)
            {
                if (!MapperBucket<TData, TBehaviour>.TryGet(out var mapper)) 
                    continue;
                
                var behaviour = await mapper.LoadAndMap(guid);
                list.Add(behaviour);
            }
        }

        public void Dispose() 
            => HashSetPool<Guid>.Release(historic);
    }
}