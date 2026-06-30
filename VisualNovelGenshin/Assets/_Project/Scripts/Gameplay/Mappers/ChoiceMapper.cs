using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Choices;

namespace Project.Core.Scripts.Managers
{
    public class ChoiceMapper : Mapper<ChoiceData, Choice>
    {
        public override Choice Map(ChoiceData data) => new Choice(data.Text);
    }
}