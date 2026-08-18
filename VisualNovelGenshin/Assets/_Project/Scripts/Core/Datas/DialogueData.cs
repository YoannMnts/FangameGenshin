using Project.Core.Scripts.Mappers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "Datas/Dialogue")]
    public class DialogueData : ScriptableData, IData
    {
        [field: SerializeReference]
        public IStoryPathSelectorData StoryPathSelector { get; private set; }
    }
}