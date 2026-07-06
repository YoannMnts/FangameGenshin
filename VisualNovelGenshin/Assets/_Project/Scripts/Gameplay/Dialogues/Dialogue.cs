using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Choices;
using Project.Gameplay.Scripts.Talks;

namespace Project.Gameplay.Scripts.Dialogues
{
    public class Dialogue : IRuntime
    {
        public readonly Talk[] dialogues;
        public readonly Choice[] choices;
        public Talk CurrentTalk { get; private set; } 
        public Dialogue(Talk[] dialogues, Choice[] choices)
        {
            this.dialogues = dialogues;
            this.choices = choices;
            CurrentTalk = dialogues[0];
        }
    }
}