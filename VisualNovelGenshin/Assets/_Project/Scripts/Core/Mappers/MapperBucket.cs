using System;
using System.Collections.Generic;

namespace Project.Core.Scripts.Mappers
{
    public static class MapperBucket<TData, TBehaviour> 
        where TData : IData
        where TBehaviour : IBehaviour<TData>
    {
        private static readonly Dictionary<Type, IMapper<TData, TBehaviour>> Mappers = new ();

        public static void Add<TMapper>(TMapper mapper) 
            where TMapper : IMapper<TData, TBehaviour>
        {
            if (!Mappers.TryAdd(typeof(TData), mapper))
                throw new ArgumentException("Mapper already exists");
        }

        public static bool TryGet(out IMapper<TData, TBehaviour> mapper)
            => Mappers.TryGetValue(typeof(TData), out mapper);
    }
}