using MonoOptimization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy Animator Module")]
    public sealed class AnimatorModule : MonoModuleAuto
    {
        [MonoComponent]
        [ShowInInspector, ReadOnly]
        public AnimatorSystem animatorSystem = new();

        [Header("States")]
        [Resolve]
        [SerializeField]
        private CommonAnimationModule commonStates = new();
        
        [Resolve]
        [SerializeField, Space]
        private IdleAnimationModule idleState = new();

        [Resolve]
        [SerializeField]
        private MoveAnimationModule moveState = new();

        [Resolve]
        [SerializeField]
        private MeleeCombatAnimationModule meleeCombatState = new();

        [Resolve]
        [SerializeField]
        private DeathAnimationModule deathState = new();

        [Resolve]
        private void Construct(VisualModule visualModule, StateMachineModule stateModule)
        {
            this.animatorSystem.Construct(visualModule.animator, visualModule.animatorDispatcher);
            this.animatorSystem.Construct(stateModule.stateMachine);

            this.animatorSystem.AddState(AnimatorStateType.IDLE, this.idleState.GetState());
            this.animatorSystem.AddState(AnimatorStateType.MOVE, this.moveState.GetState());
            this.animatorSystem.AddState(AnimatorStateType.MELEE_COMBAT, this.meleeCombatState.GetState());
            this.animatorSystem.AddState(AnimatorStateType.DEATH, this.deathState.GetState());
        }
    }
}