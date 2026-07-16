using System;
using System.Collections.Generic;
using UnityEngine.Pool;

namespace Project.Gameplay.Scripts.Storage
{
    public class Storage<TValue> : IDisposable
    {
        private readonly HashSet<TValue> historic;
        
        public Storage()
        {
            historic = HashSetPool<TValue>.Get();
        }

        public void Store(TValue value) 
            => historic.Add(value);

        public void CustomStore(Func<TValue> func) 
            => historic.Add(func());

        public void Remove(TValue value) 
            => historic.Remove(value);

        public bool Contains(TValue value) 
            => historic.Contains(value);

        public IEnumerable<TValue> GetStorage() 
            => historic;

        public void Dispose() 
            => HashSetPool<TValue>.Release(historic);
    }
}