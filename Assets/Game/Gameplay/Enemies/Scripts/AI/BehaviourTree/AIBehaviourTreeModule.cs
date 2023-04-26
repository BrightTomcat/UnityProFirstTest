using AI.BTree;
using Game.GameEngine.AI;
using MonoOptimization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy AI Behaviour Tree Module")]
    public sealed class AIBehaviourTreeModule : MonoModuleAuto
    {
        [MonoComponent]
        [ShowInInspector, ReadOnly]
        public BehaviourTreeUpdated behaviourTree = new();

        [Header("Abort Controllers")]
        [Resolve]
        [SerializeField]
        private AIModule_AbortControllers abortModule;

        [Header("Branches")]
        [Resolve]
        [SerializeField]
        private AIModule_AttackBranch attackBranch = new();

        [Resolve]
        [SerializeField]
        private AIModule_PatrolBranch patrolBranch = new();

        [Resolve]
        private void ConstructBehaviourTree()
        {
            this.behaviourTree.root = new BehaviourNode_Selector(
                this.attackBranch.GetNode(),
                this.patrolBranch.GetNode()
            );
        }

        [Resolve]
        private void ConstructBTLooper(AICoreModule coreModule)
        {
            this.behaviourTree.Construct(this.behaviourTree, coreModule.enableVariable);
        }
    }
}