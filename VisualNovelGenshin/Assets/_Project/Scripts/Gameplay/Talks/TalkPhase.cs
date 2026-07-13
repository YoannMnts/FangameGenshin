using Helteix.Tools.Phases;

namespace Project.Gameplay.Scripts.Talks
{
    public class TalkPhase : PhaseCompletionSource<bool>
    {
        public Talk Talks { get; private set; }

        public TalkPhase(Talk talks)
        {
            Talks = talks;
        }
    }
}