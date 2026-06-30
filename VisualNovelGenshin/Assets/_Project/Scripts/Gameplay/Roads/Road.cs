using Project.Gameplay.Scripts.Choices;
using Project.Gameplay.Scripts.Dialogues;

namespace Project.Gameplay.Scripts.Roads
{
    public class Road : IRuntime
    {
        public readonly Dialogue[] dialogues;
        public readonly Choice[] choices;
        public Dialogue CurrentDialogue { get; private set; } 
        public Road(Dialogue[] dialogues, Choice[] choices)
        {
            this.dialogues = dialogues;
            this.choices = choices;
            CurrentDialogue = dialogues[0];
        }
    }
}