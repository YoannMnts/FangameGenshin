using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [CreateAssetMenu(fileName = "Choice", menuName = "Datas/Choice")]
    public class ChoiceData : MapData
    {
        [field: SerializeField]
        [TextArea] 
        public string Text { get; private set; }
    }
}