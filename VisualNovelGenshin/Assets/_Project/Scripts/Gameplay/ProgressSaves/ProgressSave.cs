using System;

namespace Project.Gameplay.Scripts.ProgressSaves
{
    public partial class ProgressSave
    {
        public Guid RouteID { get; private set; }
        public Guid DialogueID { get; private set; }
        public Guid TalkID { get; private set; }
    }
}