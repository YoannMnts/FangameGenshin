using System;
using System.Threading;
using UnityEngine;

namespace Project.Core.Scripts.Mappers
{
    public abstract class Mapper<TData, TBehaviour, TSelf> : IMapper<TData, TBehaviour>
        where TData : IData
        where TBehaviour : IBehaviour<TData>
        where TSelf : Mapper<TData, TBehaviour, TSelf>, new()
    {
        private static readonly Loader<TData> Loader = new();

        public static void Register()
        {
            MapperBucket<TData, TBehaviour>.Add<TSelf>();
        }
        
        public async Awaitable<TBehaviour> LoadAndMap(Guid id, CancellationToken ct = default)
        {
            var data = await Loader.LoadAsync(id, ct);
            return await Map(data, ct);
        }
        
        public abstract Awaitable<TBehaviour> Map(TData data, CancellationToken ct = default);
    }
}