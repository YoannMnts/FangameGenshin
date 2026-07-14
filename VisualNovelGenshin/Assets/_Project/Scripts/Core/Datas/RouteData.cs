using Project.Core.Scripts.Mappers;
using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [CreateAssetMenu(fileName = "Route", menuName = "Datas/Route")]
    public class RouteData : ScriptableData, IData
    {
        [field: SerializeField]
        public DialogueData[] DaysFirstDialogue { get; private set; }
    }
}