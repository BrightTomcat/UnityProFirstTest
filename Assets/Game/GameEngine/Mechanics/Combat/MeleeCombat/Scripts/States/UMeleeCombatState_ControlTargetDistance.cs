using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Melee Combat/Melee Combat State «Control Target Distance»")]
    public sealed class UMeleeCombatState_ControlTargetDistance : UState_CheckDistanceToTarget
    {
        [Space, SerializeField]
        public UMeleeCombatEngine combatEngine;

        public IComponent_GetPosition targetComponent;

        public override void Enter()
        {
            this.targetComponent = this.combatEngine.CurrentOperation
                .targetEntity
                .Get<IComponent_GetPosition>();
            base.Enter();
        }

        protected override void OnUpdate(bool distanceReached)
        {
            if (!distanceReached)
            {
                this.combatEngine.StopCombat();
            }
        }

        protected override Vector3 GetTargetPosition()
        {
            return this.targetComponent.Position;
        }
    }
}