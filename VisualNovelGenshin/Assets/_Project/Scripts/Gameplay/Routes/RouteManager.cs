using System;
using System.Collections.Generic;
using Project.Core.Scripts.Datas;
using Project.Gameplay.Scripts.Mappers;
using UnityEngine;

namespace Project.Gameplay.Scripts.Routes
{
    public static class RouteManager
    {
        private static readonly HashSet<Guid> RoutesAlreadyDone = new();
        
        public static void AddRouteDone(RouteData data)
        {
            Debug.Log($"Adding route {data}");
            RoutesAlreadyDone.Add(data.ID);
        }

        public static void RemoveRouteDone(RouteData data)
        {
            Debug.Log($"Removing route {data}");
            RoutesAlreadyDone.Remove(data.ID);
        }
        
        public static bool HasBeenDone(Route route)
        {
            Debug.Log($"Has Been Done {RoutesAlreadyDone.Contains(route.id)}");
            return RoutesAlreadyDone.Contains(route.id);
        }
    }
}