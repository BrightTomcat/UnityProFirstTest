using Elementary;
using Entities;
using Game.GameEngine;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Dummies
{
    [AddComponentMenu("Gameplay/Dummies/Dummy Components Module")]
    public sealed class ComponentsModule : MonoModule
    {
        [SerializeField]
        private UnityEntity entity;

        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<CoreModule>();
            var configModule = context.GetModule<ConfigModule>();
            
            this.entity.Add(new Component_TransformEngine(coreModule.transformEngine));
            this.entity.Add(new Component_HitPoints(coreModule.hitPointsEngine));
            this.entity.Add(new Component_TakeDamage(coreModule.takeDamageEngine));
            this.entity.Add(new Component_Destroy_Emitter<DestroyArgs>(coreModule.destroyReceiver));
            this.entity.Add(new Component_IsAlive_HitPointsEngine(coreModule.hitPointsEngine));
            this.entity.Add(new Component_IsDestroyed_HitPointsEngine(coreModule.hitPointsEngine));
            
            this.entity.Add(new Component_ObjectType(ObjectType.ENEMY));
            this.entity.Add(new Component_GetName(new Value<string>(configModule.dummyConfig.dummyName)));
        }
    }
}