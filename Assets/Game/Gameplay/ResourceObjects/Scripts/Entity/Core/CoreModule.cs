using Elementary;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.ResourceObjects
{
    [AddComponentMenu("Gameplay/Resource Objects/Resource Core Module")]
    public sealed class CoreModule : MonoModuleAuto
    {
        [Resolve]
        [SerializeField, Space]
        public LifeModule lifeModule = new();

        [SerializeField, Space]
        public Emitter takeHitEvent = new();
    }
}