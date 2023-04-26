using Entities;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy AI Components Module")]
    public sealed class AIComponentsModule : MonoModule
    {
        [SerializeField]
        private UnityEntity entity;

        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<AICoreModule>();
            this.entity.Add(new Component_Enable(coreModule.enableVariable));
        }
    }
}