using Game.GameEngine.Mechanics;
using MonoOptimization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy State Machine Module")]
    public sealed class StateMachineModule : MonoModuleAuto
    {
        [ShowInInspector, ReadOnly]
        public StateMachine stateMachine = new();

        [Header("States")]
        [SerializeField]
        private IdleStateModule idleState = new();

        [Resolve]
        [SerializeField]
        private MoveStateModule moveState = new();

        [Resolve]
        [SerializeField]
        private MeleeCombatStateModule meleeCombatState = new();

        [SerializeField]
        private DieStateModule dieState = new();

        [Resolve]
        private void ConstructStateMachine(CoreModule coreModule)
        {
            this.stateMachine.AddState(StateType.IDLE, this.idleState.GetState());
            this.stateMachine.AddState(StateType.MOVE, this.moveState.GetState());
            this.stateMachine.AddState(StateType.MELEE_COMBAT, this.meleeCombatState.GetState());
            this.stateMachine.AddState(StateType.DEATH, this.dieState.GetState());

            this.stateMachine.Construct(
                coreModule.lifeModule.destroyEmitter,
                coreModule.meleeCombatModule.engine,
                coreModule.moveModule.engine,
                coreModule.lifeModule.respawnEvent
            );

            coreModule.enableVariable.AddListener(new BoolAction_State_EnterExit(this.stateMachine));
        }

        [Resolve]
        private void InitStateMachine(CoreModule coreModule)
        {
            if (coreModule.enableVariable.Current)
            {
                this.stateMachine.Enter();
            }
            else
            {
                this.stateMachine.Exit();
            }
        }
    }
}