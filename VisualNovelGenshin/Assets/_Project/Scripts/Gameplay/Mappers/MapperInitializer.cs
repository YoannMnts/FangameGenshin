using UnityEngine;

namespace Project.Gameplay.Scripts.Mappers
{
    public static class MapperInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            TalkMapper.Register();
            DialogueMapper.Register();
            RouteMapper.Register();
        }
    }
}