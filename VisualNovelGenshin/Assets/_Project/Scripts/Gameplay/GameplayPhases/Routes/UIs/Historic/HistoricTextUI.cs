using Helteix.Tools.UI;
using TMPro;
using UnityEngine;

namespace Project.Gameplay.Scripts.GameplayPhases.Routes.UIs.Historic
{
    public class HistoricTextUI : UIItem<string>
    {
        [SerializeField] 
        private TMP_Text text;
        
        protected override void SyncUI(string current)
        {
            text.text = current;
        }

        protected override void ClearUI()
        {
            text.text = string.Empty;
        }
    }
}