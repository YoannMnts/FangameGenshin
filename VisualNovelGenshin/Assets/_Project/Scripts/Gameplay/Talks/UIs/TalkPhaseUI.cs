using Helteix.Tools.Phases.Listeners;
using Project.Gameplay.Scripts.Utilities;
using UnityEngine;

namespace Project.Gameplay.Scripts.Talks.UIs
{
    public class TalkPhaseUI : MonoPhaseListener<TalkPhase>
    {
        public string[] TalkTexts => currentPhase.Talks.Texts;

        [SerializeField]
        private TalkUI talkUI;
        
        [SerializeField]
        private CanvasGroup group;
        
        private TalkPhase currentPhase;

        private void Awake()
        {
            group.Hide();
        }

        protected override void OnPhaseBegin(TalkPhase phase)
        {
            base.OnPhaseBegin(phase);
            
            currentPhase = phase;
            group.Show();
            talkUI.Sync(this);
        }

        protected override void OnPhaseEnd(TalkPhase phase)
        {
            talkUI.ClearUI();
            group.Hide();
            currentPhase = null;
            
            base.OnPhaseEnd(phase);
        }

        public void NextTalk(bool isRead)
        {
            currentPhase.SetResult(isRead);
        }
    }
}