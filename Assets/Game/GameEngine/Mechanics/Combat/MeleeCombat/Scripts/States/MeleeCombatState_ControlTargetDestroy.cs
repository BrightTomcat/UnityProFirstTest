using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class MeleeCombatState_ControlTargetDestroy : State
    {
        public IMeleeCombatEngine combatEngine;

        public object attacker;

        private IComponent_OnDestroyed<DestroyArgs> targetComponent;

        public MeleeCombatState_ControlTargetDestroy(IMeleeCombatEngine combatEngine, object attacker)
        {
            this.combatEngine = combatEngine;
            this.attacker = attacker;
        }

        public MeleeCombatState_ControlTargetDestroy()
        {
        }

        public override void Enter()
        {
            this.targetComponent = this.combatEngine
                .CurrentOperation
                .targetEntity
                .Get<IComponent_OnDestroyed<DestroyArgs>>();
            this.targetComponent.OnDestroyed += this.OnTargetDestroyed;
        }

        public override void Exit()
        {
            this.targetComponent.OnDestroyed -= this.OnTargetDestroyed;
        }

        private void OnTargetDestroyed(DestroyArgs destroyArgs)
        {
            if (this.IsDestroyedByAttacker(destroyArgs))
            {
                this.combatEngine.CurrentOperation.targetDestroyed = true;
            }

            this.combatEngine.StopCombat();
        }

        private bool IsDestroyedByAttacker(DestroyArgs destroyArgs)
        {
            return destroyArgs.reason == DestroyReason.ATTACKER &&
                   ReferenceEquals(destroyArgs.source, this.attacker);
        }
    }
}