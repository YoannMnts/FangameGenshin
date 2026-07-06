using Project.Core.Scripts.Mappers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [CreateAssetMenu(fileName = "Road", menuName = "Datas/Road")]
    public class RoadData : ScriptableData, IData
    {
        [field: SerializeField]
        public DayData[] Days { get; private set; }
    }
}