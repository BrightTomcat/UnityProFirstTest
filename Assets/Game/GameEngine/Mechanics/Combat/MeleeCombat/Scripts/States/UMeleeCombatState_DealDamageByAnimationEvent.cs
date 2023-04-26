using System.Collections.Generic;
using Elementary;
using Game.GameEngine.Animation;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Melee Combat/Melee Combat State «Deal Damage By Animation Event»")]
    public sealed class UMeleeCombatState_DealDamageByAnimationEvent : MonoState
    {
        [SerializeField]
        public UMeleeCombatEngine combatEngine;

        [SerializeField]
        public UMeleeCombatAction_DealDamageIfAlive damageAction;

        [Space]
        [SerializeField]
        public UAnimatorSystem animationSystem;
        
        [Space]
        [SerializeField]
        public List<string> animationEvents = new()
        {
            "harvest"
        };

        public override void Enter()
        {
            this.animationSystem.OnStringReceived += this.OnAnimationEvent;
        }

        public override void Exit()
        {
            this.animationSystem.OnStringReceived -= this.OnAnimationEvent;
        }

        private void OnAnimationEvent(string message)
        {
            if (this.animationEvents.Contains(message) && this.combatEngine.IsCombat)
            {
                this.damageAction.Do(this.combatEngine.CurrentOperation);
            }
        }
    }
}