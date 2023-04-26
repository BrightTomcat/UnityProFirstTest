using System;
using AI.BTree;
using Game.GameEngine.AI;
using MonoOptimization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class AIModule_AttackBranch
    {
        [ShowInInspector, ReadOnly]
        private BehaviourNode_Condition hasTargetNode = new();

        [ShowInInspector, ReadOnly]
        private BTNode_Entity_FollowEntityByPolygon followNode = new();

        [ShowInInspector, ReadOnly]
        private BehaviourNode_WaitForSeconds waitForSeconds = new();

        [ShowInInspector, ReadOnly]
        private BTNode_Entity_MeleeCombat combatNode = new();

        [Resolve]
        private void Construct(
            MonoBehaviour monoContext,
            AIBlackboardModule blackboardModule,
            AIConfigModule configModule
        )
        {
            var blackboard = blackboardModule.blackboard;

            var keys = configModule.aiConfig.blackboardKeys;
            var unitKey = keys.unitKey;
            var targetKey = keys.targetKey;
            var surfaceKey = keys.surfaceKey;

            var constants = configModule.aiConfig.stats;
            var meleeStoppingDistance = constants.meleeStoppingDistance;
            var pointStoppingDistance = constants.pointStoppingDistance;

            this.hasTargetNode.condition = new BTCondition_HasBlackboardVariable(blackboard, targetKey);

            this.followNode.Construct(monoContext, blackboard, meleeStoppingDistance, pointStoppingDistance);
            this.followNode.UnitKey = unitKey;
            this.followNode.TargetKey = targetKey;
            this.followNode.SurfaceKey = surfaceKey;

            this.waitForSeconds.coroutineDispatcher = monoContext;
            this.waitForSeconds.waitSeconds = 0.1f;

            this.combatNode.Construct(blackboard);
            this.combatNode.AttackerKey = unitKey;
            this.combatNode.TargetKey = targetKey;
        }

        public IBehaviourNode GetNode()
        {
            return new BehaviourNode_Sequence(
                this.hasTargetNode,
                this.followNode,
                this.waitForSeconds,
                new BehaviourNode_Decorator(this.combatNode, success: true)
            );
        }
    }
}