using System;
using Helteix.Tools.Phases;

namespace Project.Gameplay.Scripts.Choices
{
    public class ChoosePhase : PhaseCompletionSource<Guid>
    {
        public Choice[] Choices { get; private set; }

        public ChoosePhase(Choice[] choices)
        {
            Choices = choices;
        }
    }
}