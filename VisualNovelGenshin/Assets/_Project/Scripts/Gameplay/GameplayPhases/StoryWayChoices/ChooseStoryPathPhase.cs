using Helteix.Tools.Phases;

namespace Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices
{
    public class ChooseStoryPathPhase : PhaseCompletionSource<Choice>
    {
        public Choice[] Choices { get; private set; }

        public ChooseStoryPathPhase(Choice[] choices)
        {
            Choices = choices;
        }
    }
}