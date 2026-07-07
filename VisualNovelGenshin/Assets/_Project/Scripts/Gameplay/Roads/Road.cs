using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Dialogues;

namespace Project.Gameplay.Scripts.Roads
{
    public class Road : IRuntime
    {
        public readonly Dialogue[] daysFirstDialogue;

        public Road(Dialogue[] daysFirstDialogue)
        {
            this.daysFirstDialogue = daysFirstDialogue;
        }
    }
}