using System.Collections.Generic;
using System.Linq;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.StoryWayChoices;

namespace Project.Gameplay.Scripts.Dialogues
{
    public class Dialogue : IRuntime
    {
        public Choice[] Choices => GetChoices().ToArray();
        
        public StoryPath[] StoryPaths {get; private set;}
        public Dialogue(StoryPath[] storyPaths)
        {
            StoryPaths = storyPaths;
        }

        public bool TryFindStoryPath<TChoice>(TChoice choice, out StoryPath storyPath) 
            where TChoice : Choice
        {
            for (int i = 0; i < StoryPaths.Length; i++)
            {
                if (StoryPaths[i].Choice != choice) 
                    continue;
                
                storyPath = StoryPaths[i];
                return true;
            }
            
            storyPath = null;
            return false;
        }

        private IEnumerable<Choice> GetChoices()
        {
            foreach (var storyPath in StoryPaths)
            {
                yield return storyPath.Choice;
            }
        }
    }
}