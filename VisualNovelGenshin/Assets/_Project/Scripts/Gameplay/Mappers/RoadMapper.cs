using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Choices;
using Project.Gameplay.Scripts.Dialogues;
using Project.Gameplay.Scripts.Roads;

namespace Project.Core.Scripts.Managers
{
    public class RoadMapper : Mapper<RoadDataBase, Road>
    {
        private readonly DialogueMapper dialogueMapper = new();
        private readonly ChoiceMapper choiceMapper = new();

        public override Road Map(RoadDataBase data)
        {
            var dialogues = new Dialogue[data.Dialogues.Length];
            for (int i = 0; i < data.Dialogues.Length; i++)
                dialogues[i] = dialogueMapper.Map(data.Dialogues[i]);

            var choices = new Choice[data.Choices.Length];
            for (int i = 0; i < data.Choices.Length; i++)
                choices[i] = choiceMapper.Map(data.Choices[i]);

            return new Road(dialogues, choices);
        }
    }
}