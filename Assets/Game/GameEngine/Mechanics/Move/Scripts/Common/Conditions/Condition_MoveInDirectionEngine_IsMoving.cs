using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Condition_MoveInDirectionEngine_IsMoving : ICondition
    {
        private readonly IMoveInDirectionEngine engine;

        public Condition_MoveInDirectionEngine_IsMoving(IMoveInDirectionEngine engine)
        {
            this.engine = engine;
        }

        public bool IsTrue()
        {
            return this.engine.IsMoving;
        }
    }
}