using Project.Core.Scripts.Datas;

namespace Project.Core.Scripts.Mappers
{
    public interface IMapper<in TData, out TRuntime> 
        where TData : IData 
        where TRuntime : IRuntime
    { 
        TRuntime Map(TData data);
    }
}