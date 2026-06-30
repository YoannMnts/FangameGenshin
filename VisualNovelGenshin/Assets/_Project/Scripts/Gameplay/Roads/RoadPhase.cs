using System.Threading;
using Helteix.Tools.Phases;
using Project.Gameplay.Scripts.Choices;
using Project.Gameplay.Scripts.Dialogues;
using UnityEngine;

namespace Project.Gameplay.Scripts.Roads
{
    public class RoadPhase : IPhase<bool>
    {
        private readonly Road road;

        public RoadPhase(Road road)
        {
            this.road = road;
        }

        async Awaitable<bool> IPhase<bool>.Execute(CancellationToken token)
        {
            for (int i = 0; i < road.dialogues.Length; i++)
            {
                var dialogue = road.dialogues[i];
                var dialoguePhase = new DialoguePhase(dialogue);
                await dialoguePhase.Run();
            }

            var choosePhase = new ChoosePhase(road.choices);
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