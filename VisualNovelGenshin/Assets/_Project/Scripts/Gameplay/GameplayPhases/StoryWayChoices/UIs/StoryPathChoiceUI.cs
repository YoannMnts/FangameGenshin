using Helteix.Tools.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices.UIs
{
    [RequireComponent(typeof(Button))]
    public class StoryPathChoiceUI : UIItem<Choice>
    {
        [SerializeField]
        private TMP_Text text;
        
        [SerializeField]
        private Button choiceButton;

        private Choice currentChoice;
        private ChooseStoryPathPhaseUI chooseStoryPathPhaseUI;

        private void Awake()
        {
            chooseStoryPathPhaseUI = GetComponentInParent<ChooseStoryPathPhaseUI>();
        }

        protected override void SyncUI(Choice current)
        {
            currentChoice = current;
            
            text.text = currentChoice.Text;
            
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
            chooseStoryPathPhaseUI.TakeChoice(currentChoice);
        }
    }
}