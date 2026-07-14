using System;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Gameplay.Scripts.StoryWayChoices;
using Project.Gameplay.Scripts.Talks;
using UnityEngine;

namespace Project.Gameplay.Scripts.Dialogues
{
    public class DialoguePhase : IPhase<Guid>
    {
        public Dialogue Dialogue { get; private set; }
    
        private StoryPath currentStoryPath;
        private bool skipRequested;

        public DialoguePhase(Dialogue dialogue)
        {
            Dialogue = dialogue;
        }

        async Awaitable<Guid> IPhase<Guid>.Execute(CancellationToken token)
        {
            var choosePhase = new ChooseStoryPathPhase(Dialogue.Choices);
            var result = await choosePhase.Run();
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
            }
        
            return currentStoryPath.NextDialogueID;
        }

        public void WantSkip()
        {
            skipRequested = true;
        }

        async Awaitable IPhase<Guid>.Initialize(CancellationToken token)
        {
            skipRequested = false;
            await Awaitable.MainThreadAsync();
        }

        async Awaitable IPhase<Guid>.Dispose(CancellationToken token)
        {
            await Awaitable.MainThreadAsync();
        }
    }
}