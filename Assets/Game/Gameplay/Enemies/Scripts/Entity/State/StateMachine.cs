using Elementary;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public sealed class StateMachine : StateMachine<StateType>
    {
        [Space]
        [ShowInInspector, ReadOnly]
        private IEmitter<DestroyArgs> dieReceiver;

        [ShowInInspector, ReadOnly]
        private IMeleeCombatEngine combatEngine;

        [ShowInInspector, ReadOnly]
        private IMoveInDirectionEngine moveEngine;

        [ShowInInspector, ReadOnly]
        private IEmitter respawnEmitter;

        public void Construct(
            IEmitter<DestroyArgs> dieReceiver,
            IMeleeCombatEngine combatEngine,
            IMoveInDirectionEngine moveEngine,
            IEmitter respawnEmitter
        )
        {
            this.dieReceiver = dieReceiver;
            this.combatEngine = combatEngine;
            this.moveEngine = moveEngine;
            this.respawnEmitter = respawnEmitter;
        }

        public override void Enter()
        {
            base.Enter();
            this.moveEngine.OnStartMove += this.OnMoveStarted;
            this.moveEngine.OnStopMove += this.OnMoveEnded;

            this.combatEngine.OnCombatStarted += this.OnCombatStarted;
            this.combatEngine.OnCombatStopped += this.OnCombatEnded;

            this.dieReceiver.OnEvent += this.OnDestroyed;
            this.respawnEmitter.OnEvent += this.OnRespawned;
        }

        public override void Exit()
        {
            base.Exit();
            this.moveEngine.OnStartMove += this.OnMoveStarted;
            this.moveEngine.OnStopMove += this.OnMoveEnded;

            this.combatEngine.OnCombatStarted += this.OnCombatStarted;
            this.combatEngine.OnCombatStopped += this.OnCombatEnded;

            this.dieReceiver.OnEvent -= this.OnDestroyed;
            this.respawnEmitter.OnEvent -= this.OnRespawned;
        }

        private void OnMoveStarted()
        {
            this.SwitchState(StateType.MOVE);
        }

        private void OnMoveEnded()
        {
            if (this.CurrentState == StateType.MOVE)
            {
                this.SwitchState(StateType.IDLE);
            }
        }

        private void OnCombatStarted(MeleeCombatOperation operation)
        {
            this.SwitchState(StateType.MELEE_COMBAT);
        }

        private void OnCombatEnded(MeleeCombatOperation operation)
        {
            if (this.CurrentState == StateType.MELEE_COMBAT)
            {
                this.SwitchState(StateType.IDLE);
            }
        }

        private void OnDestroyed(DestroyArgs args)
        {
            this.SwitchState(StateType.DEATH);
        }

        private void OnRespawned()
        {
            if (this.CurrentState == StateType.DEATH)
            {
                this.SwitchState(StateType.IDLE);
            }
        }
    }
}