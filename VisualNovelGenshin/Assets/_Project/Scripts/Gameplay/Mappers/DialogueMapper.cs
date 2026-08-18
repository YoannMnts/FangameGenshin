using System;
using System.Threading;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.GameplayPhases.Dialogues;
using Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices;
using Project.Gameplay.Scripts.GameplayPhases.Talks;
using UnityEngine;

namespace Project.Gameplay.Scripts.Mappers
{
    public class DialogueMapper : Mapper<DialogueData,Dialogue, DialogueMapper>
    {
        public override async Awaitable<Dialogue> Map(DialogueData data, CancellationToken ct = default)
        {
            await Awaitable.MainThreadAsync();

            var storyPathDatas = data.StoryPathSelector.StoryPathDatas;
            var storyPaths = new StoryPath[storyPathDatas.Length];

            for (int i = 0; i < storyPathDatas.Length; i++)
            {
                var storyPath = storyPathDatas[i];
                
                var talks = new Talk[storyPath.Talks.Length];
                
                var storyPathTalks = storyPath.Talks;
                for (int j = 0; j < storyPathTalks.Length; j++)
                    talks[j] = new Talk(storyPathTalks[j].Texts, storyPathTalks[j].ID);

                var nextDialogueId = storyPath.NextDialogue ? 
                    storyPath.NextDialogue.ID : Guid.Empty;
                        
                storyPaths[i] = new StoryPath(talks, nextDialogueId);
            }
            
            switch (data.StoryPathSelector)
            {
                case ChoiceSelectorData choiceSelectorData:
                    var choices = new Choice[choiceSelectorData.Choices.Length];
                    
                    for (int i = 0; i < choiceSelectorData.Choices.Length; i++)
                    {
                        var choiceData = choiceSelectorData.Choices[i];
                        var choice = new Choice(choiceData.Text);
                        choices[i] = choice;
                    }
                    var choiceSelector = new ChoiceSelector(choices);
                    
                    return new Dialogue(storyPaths, choiceSelector, data.ID);
                
                case MiniGameSelectorData miniGameSelectorData:
                    var miniGameSelector = new MiniGameSelector();
                    return new Dialogue(storyPaths, miniGameSelector, data.ID);
                
                default:
                    Debug.LogError($"Story Path Selector {data.StoryPathSelector} not supported");
                    return null;
            }
            
        }
    }
    
}