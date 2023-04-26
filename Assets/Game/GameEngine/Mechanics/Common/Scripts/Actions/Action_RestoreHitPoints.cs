using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Action_RestoreHitPoints : IAction
    {
        public IHitPointsEngine hitPointsEngine;

        public Action_RestoreHitPoints(IHitPointsEngine hitPointsEngine)
        {
            this.hitPointsEngine = hitPointsEngine;
        }

        public Action_RestoreHitPoints()
        {
        }

        public void Do()
        {
            this.hitPointsEngine.AssignToMax();
        }
    }
}