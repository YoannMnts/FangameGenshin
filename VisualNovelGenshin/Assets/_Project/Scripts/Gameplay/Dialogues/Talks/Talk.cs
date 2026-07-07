using Project.Core.Scripts.Mappers;

namespace Project.Gameplay.Scripts.Talks
{
    public class Talk : IRuntime
    {
        public string Text { get; private set; }
        
        public Talk(string text)
        { 
            Text = text;
        }
    }
}