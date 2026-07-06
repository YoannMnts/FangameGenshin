using System;
using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [Serializable]
    public class TalkData
    {
        [field: SerializeField]
        [TextArea]
        public string Text { get; private set; }
    }
}