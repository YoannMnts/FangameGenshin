using System;
using Project.Core.Scripts.Mappers;
using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [CreateAssetMenu(fileName = "Talk", menuName = "Datas/Talk")]
    public class TalkData : ScriptableData, IData
    {
        [field: SerializeField, TextArea]
        public string[] Texts { get; private set; }
    }
}