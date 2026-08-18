using System;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices;
using Project.Gameplay.Scripts.GameplayPhases.Talks;
using UnityEngine;

namespace Project.Gameplay.Scripts.GameplayPhases.Dialogues
{
    public class DialoguePhase : IPhase<Guid>
    {
        public Dialogue Dialogue { get; private set; }
    
        private readonly GameManager gameManager;
        
        private StoryPath currentStoryPath;
        private bool skipRequested;
        
        public DialoguePhase(Dialogue dialogue, GameManager gameManager)
        {
            this.gameManager = gameManager;
            Dialogue = dialogue;
        }

        async Awaitable<Guid> IPhase<Guid>.Execute(CancellationToken token)
        {
            var selectPath = await Dialogue.StoryPathSelector.SelectPath(Dialogue.StoryPaths, gameManager, token);
            
            if (selectPath == null) 
                return Guid.Empty;

            currentStoryPath = selectPath;
        
            for (int i = 0; i < currentStoryPath.Talks.Length; i++)
            {
                if (skipRequested) 
                    break;
            
                var talk = currentStoryPath.Talks[i];
                var talkPhase = new TalkPhase(talk, gameManager);
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
            await Awaitable.MainThreadAsync();
            
            skipRequested = false;
        }

        async Awaitable IPhase<Guid>.Dispose(CancellationToken token)
        {
            await Awaitable.MainThreadAsync();
        }
    }
}