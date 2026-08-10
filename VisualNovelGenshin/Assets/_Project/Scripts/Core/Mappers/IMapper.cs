using System;
using System.Threading;
using UnityEngine;

namespace Project.Core.Scripts.Mappers
{
    public interface IMapper<in TData, TBehaviour> 
        where TData : IData 
        where TBehaviour : IBehaviour<TData>
    {
        Awaitable<TBehaviour> LoadAndMap(Guid id, CancellationToken ct = default);

        Awaitable<TBehaviour> Map(TData data, CancellationToken ct = default);
    }
}