using AI.BTree;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Action_AbortBehaviourTree : IAction
    {
        public IBehaviourTree behaviourTree;

        public Action_AbortBehaviourTree(IBehaviourTree behaviourTree)
        {
            this.behaviourTree = behaviourTree;
        }

        public Action_AbortBehaviourTree()
        {
        }

        public void Do()
        {
            this.behaviourTree.Abort();
        }
    }
}