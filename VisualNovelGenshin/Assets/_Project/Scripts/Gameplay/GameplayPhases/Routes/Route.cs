using System;
using Project.Core.Scripts.Datas;
using Project.Core.Scripts.Mappers;
using Project.Gameplay.Scripts.GameplayPhases.Dialogues;

namespace Project.Gameplay.Scripts.GameplayPhases.Routes
{
    public class Route : IBehaviour<RouteData>
    {
        public Guid ID { get; private set; }
        
        public Dialogue[] DaysFirstDialogue { get; private set; }
        
        public Route(Dialogue[] daysFirstDialogue, Guid id)
        {
            ID = id;
            DaysFirstDialogue = daysFirstDialogue;
        }
    }
}