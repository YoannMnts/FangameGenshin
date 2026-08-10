using UnityEngine;

namespace Project.Gameplay.Scripts.Mappers
{
    public static class MapperInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            RouteMapper.Register();
            DialogueMapper.Register();
        }
    }
}