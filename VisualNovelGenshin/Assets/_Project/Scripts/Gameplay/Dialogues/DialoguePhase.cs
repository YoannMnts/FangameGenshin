using Helteix.Tools.Phases;

namespace Project.Gameplay.Scripts.Dialogues
{
    public class DialoguePhase : PhaseCompletionSource<bool>
    {
        private readonly Dialogue dialogue;

        public DialoguePhase(Dialogue dialogue)
        {
            this.dialogue = dialogue;
        }
    }
}