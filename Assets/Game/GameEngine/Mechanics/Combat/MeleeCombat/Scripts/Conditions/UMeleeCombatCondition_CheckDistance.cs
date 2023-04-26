using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Melee Combat/Melee Combat Condition «Check Distance»")]
    public sealed class UMeleeCombatCondition_CheckDistance : UMeleeCombatCondition
    {
        [SerializeField]
        public UTransformEngine myTransform;

        [SerializeField]
        public FloatAdapter minDistance;

        public override bool IsTrue(MeleeCombatOperation value)
        {
            var targetPosition = value.targetEntity.Get<IComponent_GetPosition>().Position;
            return this.myTransform.IsDistanceReached(targetPosition, this.minDistance.Current);
        }
    }
}