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
            
            var storyPaths = new StoryPath[data.StoryPaths.Length];
            for (int i = 0; i < data.StoryPaths.Length; i++)
            {
                var storyPath = data.StoryPaths[i];
                
                var talks = new Talk[storyPath.Talks.Length];
                var storyPathTalks = storyPath.Talks;
                
                for (int j = 0; j < storyPathTalks.Length; j++)
                    talks[j] = new Talk(storyPathTalks[j].Texts, storyPathTalks[j].ID);

                var choices = new Choice(storyPath.Choice.Text);
                var nextDialogueId = storyPath.NextDialogue ? storyPath.NextDialogue.ID : Guid.Empty;
                
                storyPaths[i] = new StoryPath(choices, talks, nextDialogueId);
            }
            
            return new Dialogue(storyPaths, data.ID);
        }
    }
    
}