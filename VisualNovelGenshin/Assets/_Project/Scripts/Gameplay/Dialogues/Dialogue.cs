using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Talks;

namespace Project.Gameplay.Scripts.Dialogues
{
    public class Dialogue : IRuntime
    {
        public StoryPath[] StoryWays {get; private set;}
        public Dialogue(StoryPath[] storyWays)
        {
            StoryWays = storyWays;
        }
    }
}