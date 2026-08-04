using Helteix.Tools.Phases;
using Project.Gameplay.Scripts.GameplayPhases.Dialogues;
using Project.Gameplay.Scripts.GameplayPhases.Routes;
using Project.Gameplay.Scripts.GameplayPhases.Talks;

namespace Project.Gameplay.Scripts.ProgressSaves
{
    public partial class ProgressSave :
        IPhaseListener<RoutePhase>,
        IPhaseListener<DialoguePhase>,
        IPhaseListener<TalkPhase>
    {
        void IPhaseListener<RoutePhase>.OnPhaseBegin(RoutePhase phase)
        {
            RouteID = phase.CurrentRoute.ID;
        }

        void IPhaseListener<RoutePhase>.OnPhaseEnd(RoutePhase phase)
        {
        }

        void IPhaseListener<DialoguePhase>.OnPhaseBegin(DialoguePhase phase)
        {
            DialogueID = phase.Dialogue.ID;
        }

        void IPhaseListener<DialoguePhase>.OnPhaseEnd(DialoguePhase phase)
        {
        }

        void IPhaseListener<TalkPhase>.OnPhaseBegin(TalkPhase phase)
        {
            TalkID = phase.Talk.ID;
        }

        void IPhaseListener<TalkPhase>.OnPhaseEnd(TalkPhase phase)
        {
        }
    }
}