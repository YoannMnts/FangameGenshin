using System.Threading;
using Helteix.Tools.Phases;
using Project.Gameplay.Scripts.GameplayPhases.Dialogues;
using UnityEngine;

namespace Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices
{
    public class ChoiceSelector : IStoryPathSelector
    {
        private readonly Choice[] choices;
        
        public ChoiceSelector(Choice[] choices)
        {
            this.choices = choices;
        }
        
        public async Awaitable<StoryPath> SelectPath(StoryPath[] paths, GameManager gameManager, CancellationToken ct)
        {
            var chooseStoryPath = new SelectPathByChoicePhase(choices, gameManager);
            var result = await chooseStoryPath.Run();

            for (int i = 0; i < choices.Length; i++)
            {
                var choice = choices[i];
                
                if (choice == result.value)
                    return paths[i];
            }
            
            return null;
        }
    }
}