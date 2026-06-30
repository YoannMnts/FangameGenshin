using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "Datas/Dialogue")]
    public class DialogueData : MapData
    {
        [field: SerializeField]
        [TextArea]
        public string Text { get; private set; }
    }
}