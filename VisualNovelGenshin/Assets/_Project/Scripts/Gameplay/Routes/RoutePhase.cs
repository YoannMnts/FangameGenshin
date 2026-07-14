using System;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Core.Scripts.Datas;
using Project.Gameplay.Scripts.Dialogues;
using Project.Gameplay.Scripts.Mappers;
using UnityEngine;

namespace Project.Gameplay.Scripts.Routes
{
    public class RoutePhase : PhaseCompletionSource<bool>
    {
        public Route Route { get; private set; }
        
        private readonly Loader<DialogueData, Dialogue> dialogueLoader;

        public RoutePhase(Route route)
        {
            Route = route;
            dialogueLoader = new ();
        }

        protected override async Awaitable Initialize(CancellationToken token)
        {
            base.Initialize(token);
            
            var daysFirstDialogue = Route.daysFirstDialogue;
            for (int i = 0; i < daysFirstDialogue.Length; i++)
            {
                var currentDialogue = daysFirstDialogue[i];
                
                while (currentDialogue != null)
                {
                    var dialoguePhase = new DialoguePhase(currentDialogue);
                    var result = await dialoguePhase.Run();
                    
                    if (result.value == Guid.Empty)
                        break;
                    
                    currentDialogue = await dialogueLoader.LoadAsync<DialogueMapper>(result.value, token);
                }
            }

            SetResult(true);
        }
    }
}