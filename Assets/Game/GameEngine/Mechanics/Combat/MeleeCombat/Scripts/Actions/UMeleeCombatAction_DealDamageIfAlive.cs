using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Melee Combat/Melee Combat Action «Deal Damage If Alive»")]
    public sealed class UMeleeCombatAction_DealDamageIfAlive : UMeleeCombatAction
    {
        [SerializeField]
        public Object attacker;

        [SerializeField]
        public IntAdapter damage;
        
        public override void Do(MeleeCombatOperation operation)
        {
            var target = operation.targetEntity;
            var aliveComponent = target.Get<IComponent_IsAlive>();
            if (!aliveComponent.IsAlive)
            {
                return;
            }

            var takeDamageComponent = target.Get<IComponent_TakeDamage>();
            var damageEvent = new TakeDamageArgs(
                this.damage.Current,
                TakeDamageReason.MELEE,
                this.attacker
            );
            takeDamageComponent.TakeDamage(damageEvent);
        }
    }
}