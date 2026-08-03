using System;
using Project.Core.Scripts.Mappers;

namespace Project.Gameplay.Scripts.GameplayPhases.Talks
{
    public class Talk : IRuntime
    {
        public readonly Guid id;
        public string[] Texts { get; private set; }
        
        public Talk(string[] texts, Guid id)
        {
            this.id = id;
            Texts = texts;
        }
    }
}