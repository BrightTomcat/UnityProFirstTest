using System;
using AI.BTree;
using Game.GameEngine.AI;
using MonoOptimization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class AIModule_PatrolBranch
    {
        [ShowInInspector, ReadOnly]
        private BTNode_Iterator_AssignPosition assignPositionNode = new();

        [ShowInInspector, ReadOnly]
        private BTNode_Iterator_MoveNext moveNextPointNode = new();

        [ShowInInspector, ReadOnly]
        private BTNode_Entity_MoveToPosition moveToPositionNode = new();

        [ShowInInspector, ReadOnly]
        private BehaviourNode_WaitForSeconds waitForSecondsNode = new();

        [Resolve]
        private void Construct(
            MonoBehaviour monoContext,
            AIConfigModule configModule,
            AIBlackboardModule blackboardModule
        )
        {
            var blackboard = blackboardModule.blackboard;

            var keys = configModule.aiConfig.blackboardKeys;
            var iteratorKey = keys.patrolIteratorKey;
            var movePositionKey = keys.movePositionKey;
            var unitKey = keys.unitKey;

            var constants = configModule.aiConfig.stats;
            var pointDistance = constants.pointStoppingDistance;
            var patrolDelay = constants.patrolWaitTime;

            this.assignPositionNode.IteratorKey = iteratorKey;
            this.assignPositionNode.ResultPositionKey = movePositionKey;
            this.assignPositionNode.Construct(blackboard);

            this.moveNextPointNode.Construct(blackboard);
            this.moveNextPointNode.iteratorKey = iteratorKey;

            this.moveToPositionNode.Construct(monoContext, blackboard, pointDistance);
            this.moveToPositionNode.UnitKey = unitKey;
            this.moveToPositionNode.MovePositionKey = movePositionKey;

            this.waitForSecondsNode.coroutineDispatcher = monoContext;
            this.waitForSecondsNode.waitSeconds = patrolDelay;
        }

        public IBehaviourNode GetNode()
        {
            return new BehaviourNode_Sequence(
                this.assignPositionNode,
                this.moveNextPointNode,
                this.moveToPositionNode,
                this.waitForSecondsNode
            );
        }
    }
}