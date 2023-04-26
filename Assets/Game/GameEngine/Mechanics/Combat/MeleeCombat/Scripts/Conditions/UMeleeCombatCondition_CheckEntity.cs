using Entities;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Melee Combat/Melee Combat Condition «Check Entity»")]
    public sealed class UMeleeCombatCondition_CheckEntity : UMeleeCombatCondition
    {
        [SerializeField]
        public ScriptableEntityCondition[] conditions;

        public override bool IsTrue(MeleeCombatOperation operation)
        {
            var targetEntity = operation.targetEntity;
            for (int i = 0, count = this.conditions.Length; i < count; i++)
            {
                var condition = this.conditions[i];
                if (!condition.IsTrue(targetEntity))
                {
                    return false;
                }
            }

            return true;
        }
    }
}