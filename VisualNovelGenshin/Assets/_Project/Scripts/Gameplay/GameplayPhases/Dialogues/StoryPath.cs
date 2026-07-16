using System;
using Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices;
using Project.Gameplay.Scripts.GameplayPhases.Talks;

namespace Project.Gameplay.Scripts.GameplayPhases.Dialogues
{
    public class StoryPath
    {
        public Choice Choice {get; private set;}
        public Talk[] Talks {get; private set;}
        public Guid NextDialogueID {get; private set;}

        public StoryPath(Choice choice, Talk[] talks, Guid nextDialogueID)
        {
            Choice = choice;
            Talks = talks;
            NextDialogueID = nextDialogueID;
        }
    }
}