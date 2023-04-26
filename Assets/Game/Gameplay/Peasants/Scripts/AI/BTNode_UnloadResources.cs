using AI.Blackboards;
using AI.BTree;
using Entities;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Peasants
{
    public sealed class BTNode_UnloadResources : UnityBehaviourNode, 
        IBlackboardInjective,
        IGameConstructElement
    {
        public IBlackboard Blackboard { private get; set; }

        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        private Interactor_AddPlayerResources resourcesInteractor;

        protected override void Run()
        {
            if (!this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            this.resourcesInteractor.MoveResourcesFrom(unit);
            this.Return(true);
        }

        public void ConstructGame(IGameContext context)
        {
            this.resourcesInteractor = context.GetService<Interactor_AddPlayerResources>();
        }
    }
}