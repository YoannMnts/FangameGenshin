using Project.Core.Scripts.Mappers;

namespace Project.Gameplay.Scripts.StoryWayChoices
{
    public class Choice : IRuntime
    {
        public string Text {get; private set;}
        
        public Choice(string text)
        {
            Text = text;
        }
    }
}