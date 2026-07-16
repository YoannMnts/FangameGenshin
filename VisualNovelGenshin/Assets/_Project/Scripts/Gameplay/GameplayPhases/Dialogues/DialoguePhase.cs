using System;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices;
using Project.Gameplay.Scripts.GameplayPhases.Talks;
using Project.Gameplay.Scripts.Storage;
using UnityEngine;

namespace Project.Gameplay.Scripts.GameplayPhases.Dialogues
{
    public class DialoguePhase : IPhase<Guid>
    {
        private readonly Storage<Talk> storage;
        public Dialogue Dialogue { get; private set; }
    
        private StoryPath currentStoryPath;
        private bool skipRequested;
        
        public DialoguePhase(Dialogue dialogue, Storage<Talk> storage)
        {
            this.storage = storage;
            Dialogue = dialogue;
        }

        async Awaitable<Guid> IPhase<Guid>.Execute(CancellationToken token)
        {
            var choosePathPhase = new ChooseStoryPathPhase(Dialogue.Choices);
            var result = await choosePathPhase.Run();
            var choice = result.value;

            if (!Dialogue.TryFindStoryPath(choice, out var storyPath)) 
                return Guid.Empty;

            currentStoryPath = storyPath;
        
            for (int i = 0; i < currentStoryPath.Talks.Length; i++)
            {
                if (skipRequested) 
                    break;
            
                var talk = currentStoryPath.Talks[i];
                var talkPhase = new TalkPhase(talk);
                await talkPhase.Run();
                
                storage.Store(talk);
            }
        
            return currentStoryPath.NextDialogueID;
        }

        public void WantSkip()
        {
            skipRequested = true;
        }

        async Awaitable IPhase<Guid>.Initialize(CancellationToken token)
        {
            await Awaitable.MainThreadAsync();
            
            skipRequested = false;
        }

        async Awaitable IPhase<Guid>.Dispose(CancellationToken token)
        {
            await Awaitable.MainThreadAsync();
        }
    }
}