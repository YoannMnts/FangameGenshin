using System;
using System.Threading;
using Project.Core.Scripts.Datas;
using UnityEngine;

namespace Project.Core.Scripts.Mappers
{
    public interface ILoader<TData> 
        where TData : IData
    {
        Awaitable<TData> LoadAsync(Guid guid, CancellationToken ct);
    }
}