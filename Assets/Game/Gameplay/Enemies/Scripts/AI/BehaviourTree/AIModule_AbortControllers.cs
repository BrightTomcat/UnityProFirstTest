using System;
using Game.GameEngine.AI;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using Sirenix.OdinInspector;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class AIModule_AbortControllers
    {
        [MonoComponent]
        [ShowInInspector, ReadOnly]
        private BehaviourTreeAborter_ByBlackboard abortBlackboardController = new();

        [Resolve]
        private void Construct(
            AIBehaviourTreeModule btModule,
            AICoreModule coreModule,
            AIBlackboardModule blackboardModule,
            AIConfigModule configModule
        )
        {
            var behaviourTree = btModule.behaviourTree;
            var blackboard = blackboardModule.blackboard;
            var aiConfig = configModule.aiConfig;

            this.abortBlackboardController.Construct(behaviourTree, blackboard);
            this.abortBlackboardController.SetBlackboardKeys(aiConfig.blackboardKeys.targetKey);

            coreModule.enableVariable.AddListener(new BoolAction_AbortBehaviourTreeIfDisabled(behaviourTree));
        }
    }
}