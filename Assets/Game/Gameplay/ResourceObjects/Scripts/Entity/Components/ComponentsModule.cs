using Elementary;
using Entities;
using Game.GameEngine;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.ResourceObjects
{
    [AddComponentMenu("Gameplay/Resource Objects/Resource Components Module")]
    public sealed class ComponentsModule : MonoModule
    {
        [SerializeField]
        private UnityEntity entity;

        [Title("References")]
        [SerializeField]
        private Transform rootTransform;
        
        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<CoreModule>();
            var configModule = context.GetModule<ConfigModule>(); 
            
            this.entity.Add(new Component_Transform(this.rootTransform));
            this.entity.Add(new Component_ObjectType(ObjectType.RESOURCE_OBJECT));
            this.entity.Add(new Component_ResourceInfo(configModule.info));
            
            this.entity.Add(new Component_Hit(coreModule.takeHitEvent));
            this.entity.Add(new Component_CanDestoy_BoolVariable(coreModule.lifeModule.activeVariable));
            this.entity.Add(new Component_Destroy_Emitter(coreModule.lifeModule.destroyEvent));
        }
    }

}