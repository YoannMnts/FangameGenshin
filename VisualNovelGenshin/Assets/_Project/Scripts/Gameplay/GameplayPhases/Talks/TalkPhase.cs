using Helteix.Tools.Phases;

namespace Project.Gameplay.Scripts.GameplayPhases.Talks
{
    public class TalkPhase : PhaseCompletionSource<bool>
    {
        public Talk Talk { get; private set; }

        private readonly GameManager gameManager;
        public TalkPhase(Talk talk, GameManager gameManager)
        {
            this.gameManager = gameManager;
            Talk = talk;
            
            this.gameManager.talkHistoric.Store(Talk);
        }
    }
}