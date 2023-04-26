using System;
using Elementary;
using Game.GameEngine.Animation;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class MeleeCombatState_DoActionWhenAnimationEvent : AnimatorStateEvent
    {
        public IMeleeCombatEngine combatEngine;
        
        public IAction<MeleeCombatOperation> action;

        public MeleeCombatState_DoActionWhenAnimationEvent()
        {
        }

        public MeleeCombatState_DoActionWhenAnimationEvent(
            IMeleeCombatEngine combatEngine,
            IAction<MeleeCombatOperation> action
        )
        {
            this.combatEngine = combatEngine;
            this.action = action;
        }

        protected override void OnEvent()
        {
            if (this.combatEngine.IsCombat)
            {
                this.action.Do(this.combatEngine.CurrentOperation);
            }
        }
    }
}