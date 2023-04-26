using Game.GameEngine.GameResources;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Conveyors
{
    [AddComponentMenu("Gameplay/Conveyors/Conveyor Config Module")]
    public sealed class ConfigModule : MonoModule
    {
        [SerializeField]
        public ScriptableConveyour conveyourConfig;

        [SerializeField]
        public ResourceInfoCatalog resourceCatalog;
    }
}