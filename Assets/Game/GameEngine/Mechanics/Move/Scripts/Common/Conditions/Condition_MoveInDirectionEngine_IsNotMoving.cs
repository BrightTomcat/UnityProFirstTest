using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Condition_MoveInDirectionEngine_IsNotMoving : ICondition
    {
        private readonly IMoveInDirectionEngine engine;

        public Condition_MoveInDirectionEngine_IsNotMoving(IMoveInDirectionEngine engine)
        {
            this.engine = engine;
        }

        public bool IsTrue()
        {
            return !this.engine.IsMoving;
        }
    }
}