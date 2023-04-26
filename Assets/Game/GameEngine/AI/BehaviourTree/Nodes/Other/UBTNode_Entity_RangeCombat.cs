using AI.Blackboards;
using AI.BTree;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTNode «Range Combat» (Entity)")]
    public sealed class UBTNode_Entity_RangeCombat : UnityBehaviourNode, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;
        
        [BlackboardKey]
        [SerializeField]
        private string entityKey;

        private IComponent_RangeCombat unitComponent;
        
        protected override void Run()
        {
            if (!this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;   
            }
            
            if (!this.Blackboard.TryGetVariable(this.entityKey, out IEntity target))
            {
                this.Return(false);
                return;
            }

            this.unitComponent = unit.Get<IComponent_RangeCombat>();
            this.TryStartCombat(target);
        }

        private void TryStartCombat(IEntity target)
        {
            var operation = new RangeCombatOperation(target);
            if (this.unitComponent.CanStartCombat(operation))
            {
                this.unitComponent.OnCombatStopped += this.OnCombatFinished;
                this.unitComponent.StartCombat(operation);                
            }
            else
            {
                this.Return(false);
            }
        }

        private void OnCombatFinished(RangeCombatOperation operation)
        {
            if (this.unitComponent != null)
            {
                this.unitComponent.OnCombatStopped -= this.OnCombatFinished;
                this.unitComponent = null;
            }

            var success = operation.targetDestroyed;
            this.Return(success);
        }

        protected override void OnAbort()
        {
            if (this.unitComponent != null)
            {
                this.unitComponent.OnCombatStopped -= this.OnCombatFinished;
                this.unitComponent.StopCombat();
                this.unitComponent = null;
            }
        }
    }
}