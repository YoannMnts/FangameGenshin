using System;
using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [CreateAssetMenu(fileName = "Talk", menuName = "Datas/Talk")]
    public class TalkData : ScriptableData
    {
        [field: SerializeField, TextArea]
        public string[] Texts { get; private set; }
    }
}