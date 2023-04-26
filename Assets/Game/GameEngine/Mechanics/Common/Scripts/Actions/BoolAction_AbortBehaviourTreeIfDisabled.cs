using AI.BTree;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class BoolAction_AbortBehaviourTreeIfDisabled : IAction<bool>
    {
        public IBehaviourTree behaviourTree;

        public BoolAction_AbortBehaviourTreeIfDisabled(IBehaviourTree behaviourTree)
        {
            this.behaviourTree = behaviourTree;
        }

        public BoolAction_AbortBehaviourTreeIfDisabled()
        {
        }

        public void Do(bool isEnable)
        {
            if (!isEnable && this.behaviourTree.IsRunning)
            {
                this.behaviourTree.Abort();
            }
        }
    }
}