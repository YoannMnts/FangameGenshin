using System.Threading;
using UnityEngine;

namespace Project.Core.Scripts.Mappers
{
    public interface IAsyncMapper<in TData, TRuntime> 
        where TData : IData 
        where TRuntime : IRuntime
    { 
        Awaitable<TRuntime> MapAsync(TData data, CancellationToken ct);
    }
}