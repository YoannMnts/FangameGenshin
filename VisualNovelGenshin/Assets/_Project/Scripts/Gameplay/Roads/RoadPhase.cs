using Helteix.Tools.Phases;

namespace Project.Gameplay.Scripts.Roads
{
    public class RoadPhase : PhaseCompletionSource<int>
    {
        private readonly Road road;

        public RoadPhase(Road road)
        {
            this.road = road;
        }
    }
}