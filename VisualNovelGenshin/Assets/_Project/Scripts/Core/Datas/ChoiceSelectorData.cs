using System;
using UnityEngine;

namespace Project.Core.Scripts.Datas
{
    [Serializable]
    public class ChoiceSelectorData : IStoryPathSelectorData
    {
        [field: SerializeField]
        public ChoiceData[] Choices { get; private set; }
        
        public StoryPathData[] StoryPathDatas
        {
            get
            {
                var storyPathDatas = new StoryPathData[Choices.Length];
                for (int i = 0; i < Choices.Length; i++)
                {
                    storyPathDatas[i] = Choices[i].StoryPathData;
                }
                return storyPathDatas;
            }
        }
    }
}