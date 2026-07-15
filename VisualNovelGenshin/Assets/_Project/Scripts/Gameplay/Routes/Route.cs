using System;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Dialogues;

namespace Project.Gameplay.Scripts.Routes
{
    public struct Route : IRuntime
    {
        public readonly Guid id;
        
        public static Route Empty = new ();
        
        public Dialogue[] DaysFirstDialogue { get; private set; }
        
        public Route(Dialogue[] daysFirstDialogue, Guid id)
        {
            this.id = id;
            DaysFirstDialogue = daysFirstDialogue;
        }
    }
}