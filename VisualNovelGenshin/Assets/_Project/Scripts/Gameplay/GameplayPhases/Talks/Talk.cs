using Project.Core.Scripts.Mappers;

namespace Project.Gameplay.Scripts.GameplayPhases.Talks
{
    public class Talk : IRuntime
    {
        public string[] Texts { get; private set; }
        
        public Talk(string[] texts)
        { 
            Texts = texts;
        }
    }
}