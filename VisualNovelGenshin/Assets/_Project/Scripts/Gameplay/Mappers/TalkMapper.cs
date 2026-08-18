using System.Threading;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.GameplayPhases.Talks;
using UnityEngine;
using Talk = Project.Gameplay.Scripts.GameplayPhases.Talks.Talk;

namespace Project.Gameplay.Scripts.Mappers
{
    public class TalkMapper : Mapper<TalkData, Talk, TalkMapper>
    {
        public override async Awaitable<Talk> Map(TalkData data, CancellationToken ct = default)
        {
            await Awaitable.MainThreadAsync();
            return new Talk(data.Texts, data.ID);
        }
    }
}