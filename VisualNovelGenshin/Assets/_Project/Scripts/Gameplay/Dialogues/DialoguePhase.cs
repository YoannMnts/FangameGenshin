using System.Threading;
using Helteix.Tools.Phases;
using Project.Gameplay.Scripts.Choices;
using Project.Gameplay.Scripts.Talks;
using UnityEngine;

namespace Project.Gameplay.Scripts.Dialogues
{
    public class DialoguePhase : IPhase<bool>
    {
        private readonly Dialogue dialogue;

        public DialoguePhase(Dialogue dialogue)
        {
            this.dialogue = dialogue;
        }

        async Awaitable<bool> IPhase<bool>.Execute(CancellationToken token)
        {
            for (int i = 0; i < dialogue.dialogues.Length; i++)
            {
                var dialogue = this.dialogue.dialogues[i];
                var dialoguePhase = new TalkPhase(dialogue);
                await dialoguePhase.Run();
            }

            var choosePhase = new ChoosePhase(dialogue.choices);
            await choosePhase.Run();
            
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