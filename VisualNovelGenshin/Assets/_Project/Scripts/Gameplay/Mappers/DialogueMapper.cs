using System.Threading;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Choices;
using Project.Gameplay.Scripts.Dialogues;
using Project.Gameplay.Scripts.Talks;
using UnityEngine;

namespace Project.Gameplay.Scripts.Mappers
{
    public class DialogueMapper : IMapper<DialogueData, Dialogue>
    {
        public async Awaitable<Dialogue> Map(DialogueData data, CancellationToken ct)
        {
            await Awaitable.MainThreadAsync();
            var talks = new Talk[data.Talks.Length];
            for (int i = 0; i < data.Talks.Length; i++)
                talks[i] = new Talk(data.Talks[i].Text);

            var choices = new Choice[data.Choices.Length];
            for (int i = 0; i < data.Choices.Length; i++)
                choices[i] = new Choice(data.Choices[i].Text, data.Choices[i].NextDialogue.ID);
            
            return new Dialogue(talks, choices);
        }
    }
    
}