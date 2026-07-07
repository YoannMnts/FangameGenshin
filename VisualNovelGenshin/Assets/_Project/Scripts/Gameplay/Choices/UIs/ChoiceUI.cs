using System;
using Helteix.Tools.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Gameplay.Scripts.Choices.UIs
{
    [RequireComponent(typeof(Button))]
    public class ChoiceUI : UIItem<Choice>
    {
        [SerializeField]
        private TMP_Text text;
        
        [SerializeField]
        private Button choiceButton;

        private Choice currentChoice;
        private ChoosePhaseUI choosePhaseUI;

        private void Awake()
        {
            choosePhaseUI = GetComponentInParent<ChoosePhaseUI>();
        }

        protected override void SyncUI(Choice current)
        {
            currentChoice = current;
            
            text.text = currentChoice.text;
            
            choiceButton.onClick.AddListener(OnChoiceButtonClicked);
        }

        protected override void ClearUI()
        {
            text.text = string.Empty;
            choiceButton.onClick.RemoveAllListeners();
            currentChoice = null;
        }

        private void OnChoiceButtonClicked()
        {
            choosePhaseUI.TakeChoice(currentChoice.nextDialogueId);
        }
    }
}