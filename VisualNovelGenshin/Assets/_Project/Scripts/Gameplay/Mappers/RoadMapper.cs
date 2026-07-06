using System.Threading;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Dialogues;
using Project.Gameplay.Scripts.Roads;
using Project.Gameplay.Scripts.Roads.Days;
using UnityEngine;

namespace Project.Gameplay.Scripts.Mappers
{
    public class RoadMapper : IAsyncMapper<RoadData, Road>
    {
        private readonly DialogueLoader dialogueLoader = new ();
        
        public async Awaitable<Road> MapAsync(RoadData data, CancellationToken ct)
        {
            var days = new Day[data.Days.Length];
            
            for (int i = 0; i < data.Days.Length; i++)
            {
                var dayData = data.Days[i];
                var dialogues = new Dialogue[dayData.Dialogues.Length];
                
                for (int j = 0; j < dayData.Dialogues.Length; j++)
                {
                    dialogues[j] = await dialogueLoader.LoadAsync(dayData.Dialogues[j].ID.ToString(), ct);
                }
                
                days[i] = new Day(dialogues);
            }
            
            return new Road(days);
        }
    }
}