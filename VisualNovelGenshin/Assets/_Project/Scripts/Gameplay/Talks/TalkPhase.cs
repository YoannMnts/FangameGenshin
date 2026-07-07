using Helteix.Tools.Phases;

namespace Project.Gameplay.Scripts.Talks
{
    public class TalkPhase : PhaseCompletionSource<bool>
    {
        public Talk Talk { get; private set; }

        public TalkPhase(Talk talk)
        {
            Talk = talk;
        }
    }
}