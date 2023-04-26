using System;
using Elementary;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class MeleeCombatStateModule
    {
        [SerializeField]
        private MeleeCombatState_ControlTargetDestroy controlDestroyState = new();

        [MonoComponent]
        [SerializeField]
        private MeleeCombatState_ControlTargetDistance controlDistanceState = new();

        [Resolve]
        private void Construct(GameObject attacker, CoreModule coreModule, ConfigModule configModule)
        {
            var meleeCombatEngine = coreModule.meleeCombatModule.engine;
            var transformEngine = coreModule.transformEngine;

            this.controlDestroyState.combatEngine = meleeCombatEngine;
            this.controlDestroyState.attacker = attacker;

            this.controlDistanceState.combatEngine = meleeCombatEngine;
            this.controlDistanceState.transformEngine = transformEngine;
            this.controlDistanceState.minDistance = configModule.minMeleeDistance; 
        }

        public IState GetState()
        {
            return new StateComposite(
                this.controlDestroyState,
                this.controlDistanceState
            );
        }
    }
}