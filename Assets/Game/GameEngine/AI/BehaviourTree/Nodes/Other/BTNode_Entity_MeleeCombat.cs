using System;
using AI.Blackboards;
using AI.BTree;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [Serializable]
    public sealed class BTNode_Entity_MeleeCombat : BehaviourNode
    {
        public string AttackerKey
        {
            set => attackerKey = value;
        }

        public string TargetKey
        {
            set => targetKey = value;
        }

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string attackerKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        private IBlackboard blackboard;

        private IComponent_MeleeCombat unitComponent;

        public void Construct(IBlackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.attackerKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            if (!this.blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                this.Return(false);
                return;
            }

            this.unitComponent = unit.Get<IComponent_MeleeCombat>();
            this.TryStartCombat(target);
        }

        private void TryStartCombat(IEntity target)
        {
            var operation = new MeleeCombatOperation(target);
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

        private void OnCombatFinished(MeleeCombatOperation operation)
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