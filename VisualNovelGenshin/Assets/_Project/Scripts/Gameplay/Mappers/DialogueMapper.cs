using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Dialogues;

namespace Project.Core.Scripts.Managers
{
    
    public class DialogueMapper : Mapper<DialogueData, Dialogue>
    {
        public override Dialogue Map(DialogueData data) => new Dialogue(data.Text);
    }
    
}