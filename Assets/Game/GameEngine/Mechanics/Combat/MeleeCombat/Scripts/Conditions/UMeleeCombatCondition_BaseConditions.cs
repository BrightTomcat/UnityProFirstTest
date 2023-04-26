using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Melee Combat/Melee Combat Condition «Base Conditions»")]
    public sealed class UMeleeCombatCondition_BaseConditions : UMeleeCombatCondition
    {
        [SerializeField]
        public MonoCondition[] conditions;
        
        public override bool IsTrue(MeleeCombatOperation operation)
        {
            for (int i = 0, count = this.conditions.Length; i < count; i++)
            {
                var condition = this.conditions[i];
                if (!condition.IsTrue())
                {
                    return false;
                }
            }

            return true;
        }
    }
}