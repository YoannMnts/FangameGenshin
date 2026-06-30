using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [CreateAssetMenu(fileName = "RoadBase", menuName = "Datas/RoadDataBase")]
    public class RoadDataBase : MapData
    {
        [field: SerializeField]
        public DialogueData[] Dialogues { get; private set; }
        
        [field: SerializeField]
        public ChoiceData[] Choices { get; private set; }
    }
}