using Entities;
using Game.GameEngine;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Vendors
{
    [AddComponentMenu("Gameplay/Vendors/Vendor Components Module")]
    public sealed class ComponentsModule : MonoModule
    {
        [SerializeField]
        private UnityEntity entity;

        [Header("Refrences")]
        [SerializeField]
        private Transform particlePosition;

        public override void Construct(MonoContextModular context)
        {
            var configModule = context.GetModule<ConfigModule>();
            var vendorConfig = configModule.vendorConfig;

            var visualModule = context.GetModule<VisualModule>();
            
            this.entity.Add(new Component_Info(vendorConfig));
            this.entity.Add(new Component_ObjectType(ObjectType.VENDOR));
            this.entity.Add(new Component_CompleteDeal(visualModule.vendorVisual));
            this.entity.Add(new Component_GetParticlePosition(this.particlePosition));
        }
    }
}