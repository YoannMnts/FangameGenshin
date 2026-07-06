using Helteix.Tools.Phases;

namespace Project.Gameplay.Scripts.Talks
{
    public class TalkPhase : PhaseCompletionSource<bool>
    {
        private readonly Talk talk;

        public TalkPhase(Talk talk)
        {
            this.talk = talk;
        }
    }
}