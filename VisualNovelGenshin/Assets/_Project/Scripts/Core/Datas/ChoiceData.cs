using System;
using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [Serializable]
    public class ChoiceData
    {
        [field: SerializeField]
        [TextArea] 
        public string Text { get; private set; }
        
        [field: SerializeField]
        public StoryPathData StoryPathData { get; private set; }
    }
}