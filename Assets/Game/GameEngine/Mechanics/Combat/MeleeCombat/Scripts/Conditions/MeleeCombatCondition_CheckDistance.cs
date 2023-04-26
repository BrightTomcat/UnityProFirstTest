using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class MeleeCombatCondition_CheckDistance : ICondition<MeleeCombatOperation>
    {
        public ITransformEngine myTransform;

        public IValue<float> minDistance;

        public MeleeCombatCondition_CheckDistance(ITransformEngine myTransform, IValue<float> minDistance)
        {
            this.myTransform = myTransform;
            this.minDistance = minDistance;
        }

        public MeleeCombatCondition_CheckDistance()
        {
        }

        public bool IsTrue(MeleeCombatOperation value)
        {
            var targetPosition = value.targetEntity.Get<IComponent_GetPosition>().Position;
            return this.myTransform.IsDistanceReached(targetPosition, this.minDistance.Current);
        }
    }
}