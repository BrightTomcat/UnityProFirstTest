using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Melee Combat/Melee Combat Action «Look At Target»")]
    public sealed class UMeleeCombatAction_LookAtTarget : UMeleeCombatAction
    {
        [SerializeField]
        public UTransformEngine lookAtScript;
        
        public override void Do(MeleeCombatOperation operation)
        {
            var targetPosition = operation.targetEntity.Get<IComponent_GetPosition>().Position;
            this.lookAtScript.LookAtPosition(targetPosition);
        }
    }
}