using System.Threading;
using UnityEngine;

namespace Project.Core.Scripts.Mappers
{
    public interface IMapper<in TData, TRuntime> 
        where TData : IData 
        where TRuntime : IRuntime
    { 
        Awaitable<TRuntime> Map(TData data, CancellationToken ct);
    }
}