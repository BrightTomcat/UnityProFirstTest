using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Melee Combat/Melee Combat State «Control Target Destroy»")]
    public sealed class UMeleeCombatState_ControlTargetDestroy : MonoState
    {
        [Space, SerializeField]
        public UMeleeCombatEngine combatEngine;

        [SerializeField]
        public Object attacker;

        private IComponent_OnDestroyed<DestroyArgs> targetComponent;

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
            if (this.IsDestroyedByMe(destroyArgs))
            {
                this.combatEngine.CurrentOperation.targetDestroyed = true;
            }

            this.combatEngine.StopCombat();
        }

        private bool IsDestroyedByMe(DestroyArgs destroyArgs)
        {
            return destroyArgs.reason == DestroyReason.ATTACKER &&
                   ReferenceEquals(destroyArgs.source, this.attacker);
        }
    }
}