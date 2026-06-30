namespace Project.Gameplay.Scripts.Dialogues
{
    public class Dialogue : IRuntime
    {
        public string Text { get; private set; }
        
        public Dialogue(string text)
        { 
            Text = text;
        }
    }
}