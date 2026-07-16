using Helteix.Tools.Phases;
using Project.Gameplay.Scripts.GameplayPhases.Routes;
using Project.Gameplay.Scripts.GameplayPhases.Talks;
using Project.Gameplay.Scripts.Utilities;

namespace Project.Gameplay.Scripts.GameplayPhases.Dialogues.UIs
{
    public partial class SkipDialogueButton : 
        IPhaseListener<RoutePhase>, 
        IPhaseListener<DialoguePhase>, 
        IPhaseListener<TalkPhase>
    {
        private void OnEnable()
        {
            this.Register<RoutePhase>();
            this.Register<DialoguePhase>();
            this.Register<TalkPhase>();
        }

        private void OnDisable()
        {
            this.Unregister<RoutePhase>();
            this.Unregister<DialoguePhase>();
            this.Unregister<TalkPhase>();
        }

        void IPhaseListener<RoutePhase>.OnPhaseBegin(RoutePhase phase)
        {
            canBeShown = phase.RouteHasBeenDone;
        }

        void IPhaseListener<RoutePhase>.OnPhaseEnd(RoutePhase phase)
        {
            canBeShown = false;
        }

        void IPhaseListener<DialoguePhase>.OnPhaseBegin(DialoguePhase phase)
        {
            if(!canBeShown)
                return;
            
            currentDialoguePhase = phase;
            skipButton.onClick.RemoveAllListeners();
            skipButton.onClick.AddListener(OnSkipButtonClick);
        }

        void IPhaseListener<DialoguePhase>.OnPhaseEnd(DialoguePhase phase)
        {
            if(!canBeShown)
                return;
            
            currentDialoguePhase = null;
            skipButton.onClick.RemoveListener(OnSkipButtonClick);
        }

        void IPhaseListener<TalkPhase>.OnPhaseBegin(TalkPhase phase)
        {
            if(!canBeShown)
                return;
            
            currentTalkPhase = phase;
            group.Show();
        }

        void IPhaseListener<TalkPhase>.OnPhaseEnd(TalkPhase phase)
        {
            if(!canBeShown)
                return;
            
            currentTalkPhase = null;
            group.Hide();
        }

        
    }
}