using System;
using Helteix.Tools.Phases.Listeners;
using Project.Gameplay.Scripts.Utilities;
using UnityEngine;

namespace Project.Gameplay.Scripts.Choices.UIs
{
    public class ChoosePhaseUI : MonoPhaseListener<ChoosePhase>
    {
        [SerializeField]
        private ChoiceUIList choiceUIList;

        [SerializeField] 
        private CanvasGroup group;

        private ChoosePhase currentPhase;

        private void Awake()
        {
            group.Hide();
        }

        protected override void OnPhaseBegin(ChoosePhase phase)
        {
            base.OnPhaseBegin(phase);
            
            currentPhase = phase;
            var choices = phase.Choices;
            
            group.Show();
            choiceUIList.Connect(choices);
        }

        protected override void OnPhaseEnd(ChoosePhase phase)
        {
            base.OnPhaseEnd(phase);
            
            choiceUIList.Disconnect();
            group.Hide();
        }

        public void TakeChoice(Guid choiceId)
        {
            currentPhase.SetResult(choiceId);
        }
    }
}