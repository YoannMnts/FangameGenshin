using System;
using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [Serializable]
    public class StoryPathData
    {
        [field: SerializeField]
        public TalkData[] Talks { get; private set; }
        
        [field: SerializeField]
        public DialogueData NextDialogue { get; private set; }
    }
}