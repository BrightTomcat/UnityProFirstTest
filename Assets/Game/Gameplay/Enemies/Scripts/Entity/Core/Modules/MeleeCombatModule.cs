using System;
using System.Linq;
using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class MeleeCombatModule
    {
        [SerializeField]
        public MeleeCombatEngine engine = new();
        
        [Space]
        [SerializeField]
        public ScriptableEntityCondition[] preconditions = new ScriptableEntityCondition[0];
        
        public MeleeCombatAction_DealDamageIfAlive damageAction = new();

        [Resolve]
        private void ConstructCombat(CoreModule coreModule, ConfigModule configModule)
        {
            this.engine.AddPreconditon(new MeleeCombatCondition_CheckDistance(
                coreModule.transformEngine, configModule.minMeleeDistance
            ));
            this.engine.AddPreconditon(new MeleeCombatCondition_CheckEntity(
                this.preconditions.ToArray<IEntityCondition>()
            ));
            this.engine.AddPreconditon(new MeleeCombatCondition_BaseConditions(
                new Condition_MoveInDirectionEngine_IsNotMoving(coreModule.moveModule.engine)
            ));
            this.engine.AddStartAction(new MeleeCombatAction_LookAtTarget(
                coreModule.transformEngine)
            );
        }

        [Resolve]
        private void ConstructDamageAction(GameObject attacker, ConfigModule configModule)
        {
            this.damageAction.attacker = attacker;
            this.damageAction.damage = new Value<int>(configModule.enemyConfig.damage);
        }
    }
}