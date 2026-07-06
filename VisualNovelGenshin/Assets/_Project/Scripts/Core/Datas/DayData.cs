using System;
using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [Serializable]
    public class DayData
    {
        [field: SerializeField]
        public DialogueData[] Dialogues { get; private set; }
    }
}