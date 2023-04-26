using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class BoolAction_EnableMoveInDirection : IAction<bool>
    {
        public IMoveInDirectionEngine moveEngine;

        public BoolAction_EnableMoveInDirection(IMoveInDirectionEngine moveEngine)
        {
            this.moveEngine = moveEngine;
        }

        public BoolAction_EnableMoveInDirection()
        {
        }

        public void Do(bool enabled)
        {
            this.moveEngine.IsEnabled = enabled;
        }
    }
}