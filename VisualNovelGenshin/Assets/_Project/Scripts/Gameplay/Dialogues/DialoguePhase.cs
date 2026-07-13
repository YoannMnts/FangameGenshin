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

        public DialoguePhase(Dialogue dialogue)
        {
            Dialogue = dialogue;
        }

        async Awaitable<Guid> IPhase<Guid>.Execute(CancellationToken token)
        {
            var choosePhase = new ChooseStoryPathPhase(Dialogue.StoryWays);
            var result = await choosePhase.Run();
            
            var storyPath = result.value;

            for (int i = 0; i < storyPath.Talks.Length; i++)
            {
                var talk = storyPath.Talks[i];
                var talkPhase = new TalkPhase(talk);
                await talkPhase.Run();
            }
            
            return storyPath.NextDialogueID;
        }

        async Awaitable IPhase<Guid>.Initialize(CancellationToken token)
        {
            await Awaitable.MainThreadAsync();
        }

        async Awaitable IPhase<Guid>.Dispose(CancellationToken token)
        {
            await Awaitable.MainThreadAsync();
        }
    }
}