using System.Collections.Generic;
using Helteix.Tools.Phases.Listeners;
using Project.Gameplay.Scripts.GameplayPhases.Dialogues;
using Project.Gameplay.Scripts.GameplayPhases.Talks;
using Project.Gameplay.Scripts.Utilities;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Gameplay.Scripts.GameplayPhases.Routes.UIs.Historic
{
    public class HistoricUI : MonoPhaseListener<RoutePhase>
    {
        [SerializeField]
        private CanvasGroup group;
        
        [SerializeField]
        private HistoricTextUIList historicTextUIList;
        
        [SerializeField]
        private Button openButton;
        
        [SerializeField]
        private Button closeButton;
        
        private IEnumerable<Talk> storyHistoric;

        private void Awake()
        {
            group.Hide();
        }

        protected override void OnPhaseBegin(RoutePhase phase)
        {
            base.OnPhaseBegin(phase);
            
            storyHistoric = phase.Historic;
            openButton.onClick.AddListener(OnOpen);
            closeButton.onClick.AddListener(OnClose);
        }

        protected override void OnPhaseEnd(RoutePhase phase)
        {
            openButton.onClick.RemoveListener(OnOpen);
            closeButton.onClick.RemoveListener(OnClose);
            storyHistoric = null;
            
            base.OnPhaseEnd(phase);
        }

        private void OnOpen()
        {
            if (storyHistoric == null)
            {
                Debug.LogError($"Historic is null");
                return;
            }
            
            group.Show();
            
            List<string> allText = new List<string>();
            foreach (var story in storyHistoric)
            {
                allText.AddRange(story.Texts);
            }
            
            historicTextUIList.Connect(allText);
        }
        
        private void OnClose()
        {
            group.Hide();
            historicTextUIList.Disconnect();
        }
    }
}