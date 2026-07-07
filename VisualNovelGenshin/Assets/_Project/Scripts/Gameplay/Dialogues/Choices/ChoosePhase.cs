using Helteix.Tools.Phases;

namespace Project.Gameplay.Scripts.Choices
{
    public class ChoosePhase : PhaseCompletionSource<int>
    {
        private readonly Choice[] choices;

        public ChoosePhase(Choice[] choices)
        {
            this.choices = choices;
        }
    }
}