using Project.Gameplay.Scripts.GameplayPhases.Talks;
using Project.Gameplay.Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Gameplay.Scripts.GameplayPhases.Dialogues.UIs
{
    public partial class SkipDialogueButton : MonoBehaviour
    {
        [SerializeField] 
        private CanvasGroup group;
        
        [SerializeField]
        private Button skipButton;
        
        private DialoguePhase currentDialoguePhase;
        private TalkPhase currentTalkPhase;
        
        private bool canBeShown;

        private void Awake()
        {
            group.Hide();
        }
        
        private void OnSkipButtonClick()
        {
            currentDialoguePhase?.WantSkip();
            currentTalkPhase?.SetResult(false);
        }
    }
}
