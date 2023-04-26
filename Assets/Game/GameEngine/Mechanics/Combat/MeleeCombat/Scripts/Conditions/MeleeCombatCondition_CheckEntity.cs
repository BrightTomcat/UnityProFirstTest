using Elementary;
using Entities;

namespace Game.GameEngine.Mechanics
{
    public sealed class MeleeCombatCondition_CheckEntity : ICondition<MeleeCombatOperation>
    {
        public IEntityCondition[] conditions;

        public MeleeCombatCondition_CheckEntity(params IEntityCondition[] conditions)
        {
            this.conditions = conditions;
        }

        public bool IsTrue(MeleeCombatOperation operation)
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