using System;
using Helteix.Tools.Phases.Listeners;
using Project.Gameplay.Scripts.Utilities;
using UnityEngine;

namespace Project.Gameplay.Scripts.GameplayPhases.Routes.UIs
{
    public class RoutePhaseUI : MonoPhaseListener<RoutePhase>
    {
        [SerializeField]
        private CanvasGroup group;

        private void Awake()
        {
            group.Hide();
        }

        protected override void OnPhaseBegin(RoutePhase phase)
        {
            base.OnPhaseBegin(phase);
            
            group.Show();
        }

        protected override void OnPhaseEnd(RoutePhase phase)
        {
            group.Hide();
            
            base.OnPhaseEnd(phase);
        }
    }
}