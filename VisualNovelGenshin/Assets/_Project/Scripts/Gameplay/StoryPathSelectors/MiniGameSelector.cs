using System.Threading;
using Project.Gameplay.Scripts.GameplayPhases.Dialogues;
using UnityEngine;

namespace Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices
{
    public class MiniGameSelector : IStoryPathSelector
    {
        public async Awaitable<StoryPath> SelectPath(StoryPath[] paths, GameManager gameManager, CancellationToken ct)
        {
            await Awaitable.MainThreadAsync();
            return null;
        }
    }
}