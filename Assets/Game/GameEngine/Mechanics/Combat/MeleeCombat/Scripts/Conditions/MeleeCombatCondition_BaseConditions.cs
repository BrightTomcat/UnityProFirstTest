using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class MeleeCombatCondition_BaseConditions : ICondition<MeleeCombatOperation>
    {
        public ICondition[] conditions;

        public MeleeCombatCondition_BaseConditions(params ICondition[] conditions)
        {
            this.conditions = conditions;
        }

        public bool IsTrue(MeleeCombatOperation value)
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