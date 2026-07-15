using Helteix.Tools.Phases.Listeners;
using Project.Gameplay.Scripts.Dialogues;
using Project.Gameplay.Scripts.Utilities;
using UnityEngine;

namespace Project.Gameplay.Scripts.StoryWayChoices.UIs
{
    public class ChooseStoryPathPhaseUI : MonoPhaseListener<ChooseStoryPathPhase>
    {
        [SerializeField]
        private StoryPathChoiceUIList storyPathChoiceUIList;

        [SerializeField] 
        private CanvasGroup group;

        private ChooseStoryPathPhase currentStoryPathPhase;

        private void Awake()
        {
            group.Hide();
        }

        protected override void OnPhaseBegin(ChooseStoryPathPhase storyPathPhase)
        {
            base.OnPhaseBegin(storyPathPhase);
            
            currentStoryPathPhase = storyPathPhase;
            var choices = storyPathPhase.Choices;
            
            group.Show();
            storyPathChoiceUIList.Connect(choices);
        }

        protected override void OnPhaseEnd(ChooseStoryPathPhase storyPathPhase)
        {
            base.OnPhaseEnd(storyPathPhase);
            
            storyPathChoiceUIList.Disconnect();
            group.Hide();
        }

        public void TakeChoice(Choice choice)
        {
            currentStoryPathPhase.SetResult(choice);
        }
    }
}