using Helteix.Tools.UI;
using Project.Gameplay.Scripts.Dialogues;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Gameplay.Scripts.StoryWayChoices.UIs
{
    [RequireComponent(typeof(Button))]
    public class StoryPathChoiceUI : UIItem<StoryPath>
    {
        [SerializeField]
        private TMP_Text text;
        
        [SerializeField]
        private Button choiceButton;

        private StoryPath currentChoice;
        private ChooseStoryPathPhaseUI chooseStoryPathPhaseUI;

        private void Awake()
        {
            chooseStoryPathPhaseUI = GetComponentInParent<ChooseStoryPathPhaseUI>();
        }

        protected override void SyncUI(StoryPath current)
        {
            currentChoice = current;
            
            text.text = currentChoice.Choice.Text;
            
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