using System;
using Project.Gameplay.Scripts.GameplayPhases.StoryWayChoices;
using Project.Gameplay.Scripts.GameplayPhases.Talks;

namespace Project.Gameplay.Scripts.GameplayPhases.Dialogues
{
    public class StoryPath
    {
        public Talk[] Talks {get; private set;}
        public Guid NextDialogueID {get; private set;}

        public StoryPath(Talk[] talks, Guid nextDialogueID)
        {
            Talks = talks;
            NextDialogueID = nextDialogueID;
        }
    }
}