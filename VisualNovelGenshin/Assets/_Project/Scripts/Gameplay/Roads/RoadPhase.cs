using System;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Core.Scripts.Datas;
using Project.Gameplay.Scripts.Dialogues;
using Project.Gameplay.Scripts.Mappers;
using UnityEngine;

namespace Project.Gameplay.Scripts.Roads
{
    public class RoadPhase : PhaseCompletionSource<int>
    {
        public Road Road { get; private set; }
        
        private readonly Loader<DialogueData, Dialogue> dialogueLoader;

        public RoadPhase(Road road)
        {
            Road = road;
            dialogueLoader = new ();
        }

        protected override async Awaitable Initialize(CancellationToken token)
        {
            base.Initialize(token);
            
            var daysFirstDialogue = Road.daysFirstDialogue;
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
        }
    }
}