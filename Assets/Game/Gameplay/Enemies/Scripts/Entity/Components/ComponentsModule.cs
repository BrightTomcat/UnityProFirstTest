using Elementary;
using Entities;
using Game.GameEngine;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy Components Module")]
    public sealed class ComponentsModule : MonoModule
    {
        [SerializeField]
        public UnityEntity entity;

        [SerializeField]
        private Transform movingPivot;

        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<CoreModule>();
            this.entity.AddRange(
                new Component_TransformEngine(coreModule.transformEngine),
                new Component_Enable(coreModule.enableVariable),
                new Component_MoveInDirection(coreModule.moveModule.engine),
                new Component_MeleeCombat(coreModule.meleeCombatModule.engine),
                new Component_Respawn(coreModule.lifeModule.respawnEvent),
                new Component_HitPoints(coreModule.lifeModule.hitPointsEngine),
                new Component_TakeDamage(coreModule.lifeModule.takeDamageEngine),
                new Component_Destroy_Emitter<DestroyArgs>(coreModule.lifeModule.destroyEmitter),
                new Component_IsAlive_HitPointsEngine(coreModule.lifeModule.hitPointsEngine),
                new Component_IsDestroyed_HitPointsEngine(coreModule.lifeModule.hitPointsEngine)
            );

            var configModule = context.GetModule<ConfigModule>();
            this.entity.AddRange(
                new Component_GetName(new Value<string>(configModule.enemyConfig.enemyName)),
                new Component_GetPivot(this.movingPivot),
                new Component_ObjectType(ObjectType.ENEMY)
            );
        }
    }
}