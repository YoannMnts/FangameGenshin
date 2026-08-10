using System;

namespace Project.Core.Scripts.Mappers
{
    public interface IBehaviour
    {
    }
    public interface IBehaviour<TData> : IBehaviour where TData : IData
    {
        public Guid ID { get; }
    }
}