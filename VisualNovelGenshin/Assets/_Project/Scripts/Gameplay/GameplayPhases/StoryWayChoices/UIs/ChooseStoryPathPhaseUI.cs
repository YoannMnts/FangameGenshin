using Helteix.Tools.Phases.Listeners;
using Project.Gameplay.Scripts.Utilities;
using UnityEngine;

namespace Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices.UIs
{
    public class ChooseStoryPathPhaseUI : MonoPhaseListener<SelectPathByChoicePhase>
    {
        [SerializeField]
        private StoryPathChoiceUIList storyPathChoiceUIList;

        [SerializeField] 
        private CanvasGroup group;

        private SelectPathByChoicePhase currentPathPhase;

        private void Awake()
        {
            group.Hide();
        }

        protected override void OnPhaseBegin(SelectPathByChoicePhase pathByChoicePhase)
        {
            base.OnPhaseBegin(pathByChoicePhase);
            
            currentPathPhase = pathByChoicePhase;
            var choices = pathByChoicePhase.Choices;
            
            group.Show();
            storyPathChoiceUIList.Connect(choices);
        }

        protected override void OnPhaseEnd(SelectPathByChoicePhase pathByChoicePhase)
        {
            base.OnPhaseEnd(pathByChoicePhase);
            
            storyPathChoiceUIList.Disconnect();
            group.Hide();
        }

        public void TakeChoice(Choice choice)
        {
            currentPathPhase.SetResult(choice);
        }
    }
}