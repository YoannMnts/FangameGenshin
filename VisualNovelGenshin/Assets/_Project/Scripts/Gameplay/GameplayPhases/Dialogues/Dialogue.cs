using System;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices;

namespace Project.Gameplay.Scripts.GameplayPhases.Dialogues
{
    public class Dialogue : IBehaviour<DialogueData>
    {
        public Guid ID { get; private set; }
        public StoryPath[] StoryPaths {get; private set;}
        public IStoryPathSelector StoryPathSelector { get; private set; }
        
        public Dialogue(StoryPath[] storyPaths, IStoryPathSelector storyPathSelector, Guid id)
        {
            ID = id;
            StoryPaths = storyPaths;
            StoryPathSelector = storyPathSelector;
        }
    }
}