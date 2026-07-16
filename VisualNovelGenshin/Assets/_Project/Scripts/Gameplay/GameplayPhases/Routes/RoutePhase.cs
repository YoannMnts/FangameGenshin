using System;
using System.Collections.Generic;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Core.Scripts.Datas;
using Project.Gameplay.Scripts.GameplayPhases.Dialogues;
using Project.Gameplay.Scripts.GameplayPhases.Talks;
using Project.Gameplay.Scripts.Mappers;
using Project.Gameplay.Scripts.Storage;
using UnityEngine;

namespace Project.Gameplay.Scripts.GameplayPhases.Routes
{
    public class RoutePhase : IPhase<bool>
    {
        public IEnumerable<Talk> Historic => talkStorage.GetStorage();
        
        public bool RouteHasBeenDone => routeStorage.Contains(CurrentRoute.id);
        public Route CurrentRoute { get; private set; }
        
        private readonly Storage<Guid> routeStorage;
        private readonly Storage<Talk> talkStorage;
        
        private readonly Loader<DialogueData, Dialogue> dialogueLoader;
        
        public RoutePhase(Route currentRoute, Storage<Guid> routeStorage)
        {
            this.routeStorage = routeStorage;
            CurrentRoute = currentRoute;
            dialogueLoader = new ();
            talkStorage = new ();
        }

        async Awaitable<bool> IPhase<bool>.Execute(CancellationToken token)
        {
            var daysFirstDialogue = CurrentRoute.DaysFirstDialogue;
            for (int i = 0; i < daysFirstDialogue.Length; i++)
            {
                var currentDialogue = daysFirstDialogue[i];
                    
                while (currentDialogue != null)
                {
                    var dialoguePhase = new DialoguePhase(currentDialogue, talkStorage);
                    var result = await dialoguePhase.Run();

                    if (result.value == Guid.Empty)
                        break;
                        
                    currentDialogue = await dialogueLoader.LoadAsync<DialogueMapper>(result.value, token);
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
            talkStorage.Dispose();
        }
    }
}