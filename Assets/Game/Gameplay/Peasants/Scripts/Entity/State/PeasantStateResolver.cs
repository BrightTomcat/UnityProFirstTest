using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.Gameplay.Peasants
{
    public sealed class PeasantStateResolver : MonoBehaviour
    {
        [SerializeField]
        private PeasantStateMachine stateMachine;

        [Space]
        [SerializeField]
        private UMoveInDirectionEngine moveEngine;

        [SerializeField]
        private UMeleeCombatEngine combatEngine;

        [SerializeField]
        private UHarvestResourceEngine harvestEngine;

        #region MechanicsEvents

        private void OnMoveStarted()
        {
            this.stateMachine.SwitchState(PeasantStateType.MOVE);
        }

        private void OnMoveEnded()
        {
            var heroState = this.stateMachine.CurrentState;
            if (heroState == PeasantStateType.MOVE)
            {
                this.stateMachine.SwitchState(PeasantStateType.IDLE);
            }
        }

        private void OnHarvestStarted(HarvestResourceOperation operation)
        {
            this.stateMachine.SwitchState(PeasantStateType.HARVEST_RESOURCE);
        }

        private void OnHarvestEnded(HarvestResourceOperation operation)
        {
            if (this.stateMachine.CurrentState == PeasantStateType.HARVEST_RESOURCE)
            {
                this.stateMachine.SwitchState(PeasantStateType.IDLE);
            }
        }

        private void OnCombatStarted(MeleeCombatOperation operation)
        {
            this.stateMachine.SwitchState(PeasantStateType.MELEE_COMBAT);
        }

        private void OnCombatEnded(MeleeCombatOperation operation)
        {
            if (this.stateMachine.CurrentState == PeasantStateType.MELEE_COMBAT)
            {
                this.stateMachine.SwitchState(PeasantStateType.IDLE);
            }
        }

        #endregion

        #region UnityEvents

        private void OnEnable()
        {
            this.moveEngine.OnStartMove += this.OnMoveStarted;
            this.moveEngine.OnStopMove += this.OnMoveEnded;

            this.combatEngine.OnCombatStarted += this.OnCombatStarted;
            this.combatEngine.OnCombatStopped += this.OnCombatEnded;

            this.harvestEngine.OnHarvestStarted += this.OnHarvestStarted;
            this.harvestEngine.OnHarvestStopped += this.OnHarvestEnded;
        }

        private void OnDisable()
        {
            this.moveEngine.OnStartMove -= this.OnMoveStarted;
            this.moveEngine.OnStopMove -= this.OnMoveEnded;

            this.combatEngine.OnCombatStarted -= this.OnCombatStarted;
            this.combatEngine.OnCombatStopped -= this.OnCombatEnded;

            this.harvestEngine.OnHarvestStarted -= this.OnHarvestStarted;
            this.harvestEngine.OnHarvestStopped -= this.OnHarvestEnded;
        }

        #endregion
    }
}