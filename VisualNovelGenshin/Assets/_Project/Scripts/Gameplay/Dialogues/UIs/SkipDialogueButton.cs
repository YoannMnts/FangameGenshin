using Helteix.Tools.Phases;
using Project.Gameplay.Scripts.Routes;
using Project.Gameplay.Scripts.Talks;
using Project.Gameplay.Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Gameplay.Scripts.Dialogues.UIs
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
