using System;
using System.Collections.Generic;
using Helteix.Tools.Phases.Listeners;
using Project.Gameplay.Scripts.GameplayPhases.Dialogues;
using Project.Gameplay.Scripts.GameplayPhases.Talks;
using Project.Gameplay.Scripts.Utilities;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Serialization;
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

        private Awaitable<IEnumerable<Talk>> StoryHistoric => currentPhase.TalkHistoric;
        private RoutePhase currentPhase;

        private void Awake()
        {
            group.Hide();
        }

        protected override void OnPhaseBegin(RoutePhase phase)
        {
            base.OnPhaseBegin(phase);
            
            currentPhase = phase;
            openButton.onClick.AddListener(OnOpen);
            closeButton.onClick.AddListener(OnClose);
        }

        protected override void OnPhaseEnd(RoutePhase phase)
        {
            openButton.onClick.RemoveListener(OnOpen);
            closeButton.onClick.RemoveListener(OnClose);
            currentPhase = null;
            
            base.OnPhaseEnd(phase);
        }

        private async void OnOpen()
        {
            try
            {
                var talks = await currentPhase.TalkHistoric;
                var texts = new List<string>();

                foreach (var talk in talks)
                    texts.AddRange(talk.Texts);
    
                group.Show();
        
                historicTextUIList.Connect(texts);
            }
            
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
        
        
        private void OnClose()
        {
            group.Hide();
            historicTextUIList.Disconnect();
        }
    }
}