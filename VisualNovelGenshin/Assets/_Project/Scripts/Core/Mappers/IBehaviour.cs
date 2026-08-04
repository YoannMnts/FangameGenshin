using System;

namespace Project.Core.Scripts.Mappers
{
    public interface IBehaviour
    {
        public Guid ID { get; }
    }
    public interface IBehaviour<TData> : IBehaviour where TData : IData
    {
        Type DataType => typeof(TData);
    }
}