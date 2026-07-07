using UnityEngine;

namespace Project.Gameplay.Scripts.Utilities
{
    public static class UIManager
    {
        public static void Hide(this CanvasGroup group)
        {
            group.alpha = 0;
            group.interactable = false;
            group.blocksRaycasts = false;
        }
        
        public static void Show(this CanvasGroup group)
        {
            group.alpha = 1;
            group.interactable = true;
            group.blocksRaycasts = true;
        }

    }
}