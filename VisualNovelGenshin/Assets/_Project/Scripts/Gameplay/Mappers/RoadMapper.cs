using System.Threading;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Dialogues;
using Project.Gameplay.Scripts.Roads;
using UnityEngine;

namespace Project.Gameplay.Scripts.Mappers
{
    public class RoadMapper : IMapper<RoadData, Road>
    {
        private readonly Loader<DialogueData, Dialogue> dialogueLoader = new ();
        public async Awaitable<Road> Map(RoadData data, CancellationToken ct)
        {
            var dialogues = new Dialogue[data.DaysFirstDialogue.Length];
            
            for (int i = 0; i < data.DaysFirstDialogue.Length; i++)
            {
                dialogues[i] = await dialogueLoader.LoadAsync<DialogueMapper>(data.DaysFirstDialogue[i].ID.ToString(), ct);
            }
            
            return new Road(dialogues);
        }
    }
}