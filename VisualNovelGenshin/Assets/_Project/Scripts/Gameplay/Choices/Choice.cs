namespace Project.Gameplay.Scripts.Choices
{
    public class Choice : IRuntime
    {
        public string Text { get; private set; }

        public Choice(string text)
        {
            Text = text;
        }
    }
}