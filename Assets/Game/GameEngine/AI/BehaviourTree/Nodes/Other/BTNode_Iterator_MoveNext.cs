using System.Collections.Generic;
using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Game.GameEngine.AI
{
    public sealed class BTNode_Iterator_MoveNext : BehaviourNode
    {
        [BlackboardKey]
        [SerializeField]
        public string iteratorKey;

        private IBlackboard blackboard;

        public void Construct(IBlackboard blackboard)
        {
            this.blackboard = blackboard;
        }
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.iteratorKey, out IEnumerator<Vector3> iterator))
            {
                this.Return(false);
                return;
            }
        
            iterator.MoveNext();
            this.Return(true);
        }
    }
}