using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Dialogues;

namespace Project.Gameplay.Scripts.Routes
{
    public class Route : IRuntime
    {
        public readonly Dialogue[] daysFirstDialogue;

        public Route(Dialogue[] daysFirstDialogue)
        {
            this.daysFirstDialogue = daysFirstDialogue;
        }
    }
}