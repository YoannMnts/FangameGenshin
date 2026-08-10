using System;
using System.Collections.Generic;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.GameplayPhases.Dialogues;
using Project.Gameplay.Scripts.GameplayPhases.Talks;
using UnityEngine;

namespace Project.Gameplay.Scripts.GameplayPhases.Routes
{
    public class RoutePhase : IPhase<bool>
    {
        public IEnumerable<Talk> TalkHistoric => gameManager.TalkHistoric.GetBehaviours();
        public bool RouteHasBeenDone => gameManager.RouteHasBeenDone;
        
        
        public Route CurrentRoute { get; private set; }
        
        private readonly GameManager gameManager;
        public RoutePhase(Route currentRoute, GameManager gameManager)
        {
            this.gameManager = gameManager;
            CurrentRoute = currentRoute;
        }

        async Awaitable<bool> IPhase<bool>.Execute(CancellationToken token)
        {
            var daysFirstDialogue = CurrentRoute.DaysFirstDialogue;
            for (int i = 0; i < daysFirstDialogue.Length; i++)
            {
                var currentDialogue = daysFirstDialogue[i];
                    
                while (currentDialogue != null)
                {
                    var dialoguePhase = new DialoguePhase(currentDialogue, gameManager);
                    var result = await dialoguePhase.Run();

                    if (result.value == Guid.Empty)
                        break;

                    currentDialogue = MapperBucket<DialogueData, Dialogue>.TryGet(out var mapper)
                        ? await mapper.LoadAndMap(result.value, token)
                        : null;
                }
            }
            
            return true;
        }

        async Awaitable IPhase<bool>.Initialize(CancellationToken token)
        {
            await Awaitable.MainThreadAsync();
        }

        async Awaitable IPhase<bool>.Dispose(CancellationToken token)
        {
            await Awaitable.MainThreadAsync();
        }
    }
}