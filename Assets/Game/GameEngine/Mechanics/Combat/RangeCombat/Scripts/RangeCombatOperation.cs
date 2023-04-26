using Entities;
using Sirenix.OdinInspector;

namespace Game.GameEngine.Mechanics
{
    public sealed class RangeCombatOperation
    {
        [ShowInInspector]
        public IEntity targetEntity;

        [ReadOnly]
        [ShowInInspector]
        public bool targetDestroyed;

        public RangeCombatOperation(IEntity target)
        {
            this.targetEntity = target;
        }

        public RangeCombatOperation()
        {
        }
    }
}