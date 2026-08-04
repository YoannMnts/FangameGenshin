using System.Threading;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.GameplayPhases.Dialogues;
using Project.Gameplay.Scripts.GameplayPhases.Routes;
using UnityEngine;

namespace Project.Gameplay.Scripts.Mappers
{
    public class RouteMapper : IMapper<RouteData, Route>
    {
        public RouteMapper()
        {
            MapperBucket<RouteData, Route>.Add(this);
        }
        
        private readonly Loader<DialogueData> dialogueLoader = new ();
        private readonly DialogueMapper dialogueMapper = new ();
        public async Awaitable<Route> Map(RouteData data, CancellationToken ct)
        {
            var dialogues = new Dialogue[data.DaysFirstDialogue.Length];
            
            for (int i = 0; i < data.DaysFirstDialogue.Length; i++)
            {
                var dialogueData = await dialogueLoader.LoadAsync(data.DaysFirstDialogue[i].ID, ct);
                dialogues[i] = await dialogueMapper.Map(dialogueData, ct);
            }
            
            return new Route(dialogues, data.ID);
        }
    }
}