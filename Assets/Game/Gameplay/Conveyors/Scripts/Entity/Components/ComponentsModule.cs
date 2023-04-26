using Entities;
using Game.GameEngine;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Conveyors
{
    [AddComponentMenu("Gameplay/Conveyors/Conveyor Components Module")]
    public sealed class ComponentsModule : MonoModule
    {
        [SerializeField]
        public UnityEntity entity;

        [Header("References")]
        [SerializeField]
        private Transform particlePoint;
        
        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<CoreModule>();   
            var configModule = context.GetModule<ConfigModule>();
            var config = configModule.conveyourConfig;
            
            this.entity.Add(new Component_Id(config.id));
            this.entity.Add(new Component_Enable(coreModule.enableVariable));
            this.entity.Add(new Component_ObjectType(ObjectType.CONVEYOR));
            this.entity.Add(new Component_LoadZone(coreModule.loadStorage, config.inputResourceType));
            this.entity.Add(new Component_UnloadZone(coreModule.unloadStorage, config.outputResourceType, this.particlePoint));
        }
    }
}