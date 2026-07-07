using System.Threading;
using Project.Core.Scripts.Datas;
using UnityEngine;

namespace Project.Core.Scripts.Mappers
{
    public interface ILoader<TData, TRuntime> 
        where TData : IData
        where TRuntime : IRuntime
    {
        Awaitable<TRuntime> LoadAsync<TMapper>(string key, CancellationToken ct) 
            where TMapper : IMapper<TData, TRuntime>, new();
    }
}