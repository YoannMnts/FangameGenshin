using System.Collections.Generic;

namespace Project.Gameplay.Scripts.Routes
{
    public static class RouteManager
    {
        private static readonly List<Route> RoutesAlreadyDone;

        static RouteManager()
        {
            RoutesAlreadyDone = new();
        }
        
        public static void AddRouteDone(Route route)
        {
            RoutesAlreadyDone.Add(route);
        }

        public static void RemoveRouteDone(Route route)
        {
            RoutesAlreadyDone.Remove(route);
        }

        public static bool HasBeenDone(Route route)
        {
            return RoutesAlreadyDone.Contains(route);
        }
    }
}