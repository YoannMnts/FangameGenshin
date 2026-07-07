using System;
using System.Threading;
using Helteix.Tools.Phases;
using Project.Gameplay.Scripts.Choices;
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
            for (int i = 0; i < Dialogue.dialogues.Length; i++)
            {
                var talk = Dialogue.dialogues[i];
                var dialoguePhase = new TalkPhase(talk);
                await dialoguePhase.Run();
            }

            var choosePhase = new ChoosePhase(Dialogue.choices);
            var nextDialogue = await choosePhase.Run();
            
            return nextDialogue.value;
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