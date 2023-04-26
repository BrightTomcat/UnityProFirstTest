using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class MeleeCombatAction_LookAtTarget : IAction<MeleeCombatOperation>
    {
        public ITransformEngine transform;

        public MeleeCombatAction_LookAtTarget(ITransformEngine transform)
        {
            this.transform = transform;
        }

        public MeleeCombatAction_LookAtTarget()
        {
        }

        public void Do(MeleeCombatOperation operation)
        {
            var targetPosition = operation.targetEntity.Get<IComponent_GetPosition>().Position;
            this.transform.LookAtPosition(targetPosition);
        }
    }
}