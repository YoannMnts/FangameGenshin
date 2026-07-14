using Helteix.Tools.Phases;
using Project.Gameplay.Scripts.Dialogues;

namespace Project.Gameplay.Scripts.StoryWayChoices
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