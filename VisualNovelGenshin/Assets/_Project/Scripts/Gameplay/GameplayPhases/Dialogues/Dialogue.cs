using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices;

namespace Project.Gameplay.Scripts.GameplayPhases.Dialogues
{
    public class Dialogue : IRuntime
    {
        public Choice[] Choices => GetChoices();
        
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

        private Choice[] GetChoices()
        {
            var choices = new Choice[StoryPaths.Length];
            for (var i = 0; i < StoryPaths.Length; i++)
            {
                var storyPath = StoryPaths[i];
                choices[i] = StoryPaths[i].Choice;
            }
            
            return choices;
        }
    }
}