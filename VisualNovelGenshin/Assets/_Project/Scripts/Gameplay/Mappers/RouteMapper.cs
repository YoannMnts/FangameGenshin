using System.Threading;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.GameplayPhases.Dialogues;
using Project.Gameplay.Scripts.GameplayPhases.Routes;
using UnityEngine;

namespace Project.Gameplay.Scripts.Mappers
{
    public class RouteMapper : Mapper<RouteData, Route, RouteMapper>
    {
        public override async Awaitable<Route> Map(RouteData data, CancellationToken ct = default)
        {
            var dialogues = new Dialogue[data.DaysFirstDialogue.Length];

            if (!MapperBucket<DialogueData, Dialogue>.TryGet(out var mapper))
            {
                return null;
            }
            
            for (int i = 0; i < data.DaysFirstDialogue.Length; i++)
            {
                dialogues[i] = await mapper.Map(data.DaysFirstDialogue[i], ct);
            }
            
            return new Route(dialogues, data.ID);
        }
    }
}