using System.Threading;
using UnityEngine;

namespace Project.Core.Scripts.Mappers
{
    public interface IMapper<in TData, TBehaviour> 
        where TData : IData 
        where TBehaviour : IBehaviour<TData>
    { 
        Awaitable<TBehaviour> Map(TData data, CancellationToken ct = default);
    }
}