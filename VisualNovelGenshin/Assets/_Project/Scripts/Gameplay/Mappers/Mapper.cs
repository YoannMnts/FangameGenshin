using System.Threading;
using Project.Core.Scripts.Mappers;
using UnityEngine;

namespace Project.Gameplay.Scripts.Mappers
{
    public abstract class Mapper<TData, TRuntime> : IMapper<TData, TRuntime>
        where TData : IData
        where TRuntime : IRuntime
    {
        public abstract Awaitable<TRuntime> Map(TData data, CancellationToken ct);
    }
}