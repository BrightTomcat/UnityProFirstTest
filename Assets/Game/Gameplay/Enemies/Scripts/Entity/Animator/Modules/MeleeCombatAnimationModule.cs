using System;
using System.ComponentModel;
using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class MeleeCombatAnimationModule
    {
        private StateComposite stateComposite = new();

        [SerializeField]
        private MeleeCombatState_DoActionWhenAnimationEvent dealDamageState = new();

        [Resolve]
        private void AddCommonStates(CommonAnimationModule commonStateModule)
        {
            this.stateComposite.AddState(commonStateModule.resetRootMotionState);
        }

        [Resolve]
        private void AddMeleeState(AnimatorModule animModule, CoreModule coreModule)
        {
            this.dealDamageState.animationSystem = animModule.animatorSystem;
            this.dealDamageState.combatEngine = coreModule.meleeCombatModule.engine;
            this.dealDamageState.action = coreModule.meleeCombatModule.damageAction;

            this.stateComposite.AddState(this.dealDamageState);
        }

        public IState GetState()
        {
            return this.stateComposite;
        }
    }
}