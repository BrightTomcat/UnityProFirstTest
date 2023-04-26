using System.Runtime.Serialization;
using Elementary;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    public sealed class HeroStateResolver : MonoBehaviour
    {
        [SerializeField]
        private HeroStateMachine stateMachine;

        [Space]
        [OptionalField]
        [SerializeField]
        private UMoveInDirectionEngine moveEngine;

        [OptionalField]
        [SerializeField]
        private UMeleeCombatEngine combatEngine;

        [OptionalField]
        [SerializeField]
        private UHarvestResourceEngine harvestEngine;

        [OptionalField]
        [SerializeField]
        private DestroyEventReceiver destroyReceiver;

        [OptionalField]
        [SerializeField]
        private MonoEmitter respawnReceiver;

        private void OnEnable()
        {
            if (this.moveEngine != null)
            {
                this.moveEngine.OnStartMove += this.OnMoveStarted;
                this.moveEngine.OnStopMove += this.OnMoveEnded;
            }

            if (this.combatEngine != null)
            {
                this.combatEngine.OnCombatStarted += this.OnCombatStarted;
                this.combatEngine.OnCombatStopped += this.OnCombatEnded;
            }

            if (this.harvestEngine != null)
            {
                this.harvestEngine.OnHarvestStarted += this.OnHarvestStarted;
                this.harvestEngine.OnHarvestStopped += this.OnHarvestEnded;
            }

            if (this.destroyReceiver != null)
            {
                this.destroyReceiver.OnDestroy += this.OnDied;
            }

            if (this.respawnReceiver != null)
            {
                this.respawnReceiver.OnEvent += this.OnRespawned;
            }
        }

        private void OnDisable()
        {
            if (this.moveEngine != null)
            {
                this.moveEngine.OnStartMove -= this.OnMoveStarted;
                this.moveEngine.OnStopMove -= this.OnMoveEnded;
            }

            if (this.combatEngine != null)
            {
                this.combatEngine.OnCombatStarted -= this.OnCombatStarted;
                this.combatEngine.OnCombatStopped -= this.OnCombatEnded;
            }

            if (this.harvestEngine != null)
            {
                this.harvestEngine.OnHarvestStarted -= this.OnHarvestStarted;
                this.harvestEngine.OnHarvestStopped -= this.OnHarvestEnded;
            }

            if (this.destroyReceiver != null)
            {
                this.destroyReceiver.OnDestroy -= this.OnDied;
            }

            if (this.respawnReceiver != null)
            {
                this.respawnReceiver.OnEvent -= this.OnRespawned;
            }
        }

        #region MechanicsEvents

        private void OnDied(DestroyArgs destroyArgs)
        {
            this.stateMachine.SwitchState(HeroStateType.DEATH);
        }

        private void OnMoveStarted()
        {
            this.stateMachine.SwitchState(HeroStateType.MOVE);
        }

        private void OnMoveEnded()
        {
            if (this.stateMachine.CurrentState == HeroStateType.MOVE)
            {
                this.stateMachine.SwitchState(HeroStateType.IDLE);
            }
        }

        private void OnHarvestStarted(HarvestResourceOperation operation)
        {
            this.stateMachine.SwitchState(HeroStateType.HARVEST_RESOURCE);
        }

        private void OnHarvestEnded(HarvestResourceOperation operation)
        {
            if (this.stateMachine.CurrentState == HeroStateType.HARVEST_RESOURCE)
            {
                this.stateMachine.SwitchState(HeroStateType.IDLE);
            }
        }

        private void OnCombatStarted(MeleeCombatOperation operation)
        {
            this.stateMachine.SwitchState(HeroStateType.MELEE_COMBAT);
        }

        private void OnCombatEnded(MeleeCombatOperation operation)
        {
            if (this.stateMachine.CurrentState == HeroStateType.MELEE_COMBAT)
            {
                this.stateMachine.SwitchState(HeroStateType.IDLE);
            }
        }

        private void OnRespawned()
        {
            if (this.stateMachine.CurrentState == HeroStateType.DEATH)
            {
                this.stateMachine.SwitchState(HeroStateType.IDLE);
            }
        }

        #endregion
    }
}