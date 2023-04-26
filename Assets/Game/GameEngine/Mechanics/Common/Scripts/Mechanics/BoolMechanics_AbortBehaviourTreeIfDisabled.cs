using AI.BTree;

namespace Game.GameEngine.Mechanics
{
    public sealed class BoolMechanics_AbortBehaviourTreeIfDisabled : BoolMechanics
    {
        public IBehaviourTree behaviourTree;

        protected override void SetValue(bool isEnable)
        {
            if (isEnable && this.behaviourTree.IsRunning)
            {
                this.behaviourTree.Abort();
            }
        }
    }
}