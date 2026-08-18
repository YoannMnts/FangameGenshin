using Helteix.Tools.Phases;

namespace Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices
{
    public class SelectPathByChoicePhase : PhaseCompletionSource<Choice>
    {
        public Choice[] Choices { get; private set; }

        private readonly GameManager gameManager;
        public SelectPathByChoicePhase(Choice[] choices, GameManager gameManager)
        {
            this.gameManager = gameManager;
            Choices = choices;
        }
    }
}