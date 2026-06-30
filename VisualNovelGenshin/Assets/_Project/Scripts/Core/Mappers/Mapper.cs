using Project.Core.Scripts.Datas;
using Project.Gameplay.Scripts;

namespace Project.Core.Scripts.Mappers
{
    public abstract class Mapper<TData, TRuntime> 
        where TData : IData 
        where TRuntime : IRuntime
    {
        public abstract TRuntime Map(TData data);
    }
}