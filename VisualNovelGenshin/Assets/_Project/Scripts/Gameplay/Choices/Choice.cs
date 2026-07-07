using System;
using Project.Core.Scripts.Mappers;

namespace Project.Gameplay.Scripts.Choices
{
    public class Choice : IRuntime
    {
        public readonly Guid nextDialogueId;
        public readonly string text;
        
        public Choice(string text, Guid nextDialogueId)
        {
            this.nextDialogueId = nextDialogueId;
            this.text = text;
        }
    }
}