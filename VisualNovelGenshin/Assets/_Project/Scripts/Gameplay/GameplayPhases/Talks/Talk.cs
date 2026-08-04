using System;
using Project.Core.Scripts.Mappers;

namespace Project.Gameplay.Scripts.GameplayPhases.Talks
{
    public class Talk : IBehaviour
    {
        public Guid ID { get; private set; }
        public string[] Texts { get; private set; }
        
        public Talk(string[] texts, Guid id)
        {
            Texts = texts;
        }

    }
}