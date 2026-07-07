using Project.Core.Scripts.Mappers;
using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [CreateAssetMenu(fileName = "Road", menuName = "Datas/Road")]
    public class RoadData : ScriptableData, IData
    {
        [field: SerializeField]
        public DialogueData[] DaysFirstDialogue { get; private set; }
    }
}