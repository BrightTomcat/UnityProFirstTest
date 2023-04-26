using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Action_InterruptMoveInDirection : IAction
    {
        public IMoveInDirectionEngine engine;

        public Action_InterruptMoveInDirection(IMoveInDirectionEngine engine)
        {
            this.engine = engine;
        }

        public Action_InterruptMoveInDirection()
        {
        }

        public void Do()
        {
            this.engine.InterruptMove();
        }
    }
}