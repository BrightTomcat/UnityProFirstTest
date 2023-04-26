using System;
using AI.Blackboards;
using AI.BTree;
using Elementary;
using Entities;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [Serializable]
    public sealed class BTNode_Entity_MoveToPosition : BehaviourNode
    {
        public string UnitKey
        {
            set => unitKey = value;
        }

        public string MovePositionKey
        {
            set => movePositionKey = value;
        }

        private IBlackboard blackboard;

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string movePositionKey;

        private Agent_Entity_MoveToPosition moveAgent;

        public void Construct(
            MonoBehaviour monoContext,
            IBlackboard blackboard,
            float stoppingDistance
        )
        {
            this.blackboard = blackboard;

            this.moveAgent = new Agent_Entity_MoveToPosition(monoContext);
            this.moveAgent.SetStoppingDistance(stoppingDistance);
        }

        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity entity))
            {
                this.Return(false);
                return;
            }

            if (!this.blackboard.TryGetVariable(this.movePositionKey, out Vector3 targetPosition))
            {
                this.Return(false);
                return;
            }

            this.moveAgent.OnTargetReached += this.OnTargetReached;
            this.moveAgent.SetMovingEntity(entity);
            this.moveAgent.SetTarget(targetPosition);
            this.moveAgent.Play();
        }

        private void OnTargetReached(bool isReached)
        {
            if (isReached)
            {
                this.Return(true);
            }
        }

        protected override void OnEnd()
        {
            this.moveAgent.OnTargetReached -= this.OnTargetReached;
            this.moveAgent.Stop();
        }
    }
}