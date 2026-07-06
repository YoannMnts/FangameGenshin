using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.Roads.Days;

namespace Project.Gameplay.Scripts.Roads
{
    public class Road : IRuntime
    {
        public readonly Day[] days;

        public Road(Day[] days)
        {
            this.days = days;
        }
    }
}