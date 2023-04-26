using System;
using AI.BTree;
using Elementary;
using MonoOptimization;

namespace Game.GameEngine.AI
{
    [Serializable]
    public sealed class BehaviourTreeUpdated : BehaviourTree, IUpdateComponent
    {
        private IBehaviourTree behaviourTree;
        
        private IValue<bool> isEnable;

        public void Construct(IBehaviourTree behaviourTree, IValue<bool> isEnable)
        {
            this.behaviourTree = behaviourTree;
            this.isEnable = isEnable;
        }

        void IUpdateComponent.Update(float deltaTime)
        {
            if (this.isEnable.Current)
            {
                this.behaviourTree.Run();
            }   
        }
    }
}