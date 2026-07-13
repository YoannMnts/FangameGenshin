using Helteix.Tools.Phases;
using Project.Gameplay.Scripts.Dialogues;

namespace Project.Gameplay.Scripts.StoryWayChoices
{
    public class ChooseStoryPathPhase : PhaseCompletionSource<StoryPath>
    {
        public StoryPath[] StoryWays { get; private set; }

        public ChooseStoryPathPhase(StoryPath[] storyWays)
        {
            StoryWays = storyWays;
        }
    }
}