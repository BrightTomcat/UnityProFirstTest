using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class MeleeCombatState_ControlTargetDistance : State_CheckDistanceToTarget
    {
        public IMeleeCombatEngine combatEngine;

        private IComponent_GetPosition targetComponent;

        public MeleeCombatState_ControlTargetDistance()
        {
        }

        public MeleeCombatState_ControlTargetDistance(IMeleeCombatEngine combatEngine)
        {
            this.combatEngine = combatEngine;
        }

        protected override void OnEnter()
        {
            this.targetComponent = this.combatEngine
                .CurrentOperation
                .targetEntity
                .Get<IComponent_GetPosition>();
        }
        
        protected override void ProcessDistance(bool distanceReached)
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