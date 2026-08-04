using Helteix.Tools.Phases;

namespace Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices
{
    public class ChooseStoryPathPhase : PhaseCompletionSource<Choice>
    {
        public Choice[] Choices { get; private set; }

        private readonly GameManager gameManager;
        public ChooseStoryPathPhase(Choice[] choices, GameManager gameManager)
        {
            this.gameManager = gameManager;
            Choices = choices;
        }
    }
}