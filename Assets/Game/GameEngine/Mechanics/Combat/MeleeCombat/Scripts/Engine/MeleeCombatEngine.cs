using System;
using System.Collections.Generic;
using Elementary;
using Sirenix.OdinInspector;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class MeleeCombatEngine : IMeleeCombatEngine
    {
        public event Action<MeleeCombatOperation> OnCombatStarted;

        public event Action<MeleeCombatOperation> OnCombatStopped;

        [ShowInInspector, ReadOnly, PropertyOrder(-10), PropertySpace]
        public bool IsCombat
        {
            get { return this.CurrentOperation != null; }
        }

        [ShowInInspector, ReadOnly, PropertyOrder(-9)]
        public MeleeCombatOperation CurrentOperation { get; private set; }

        [ShowInInspector, ReadOnly, PropertyOrder(-8), PropertySpace]
        private List<ICondition<MeleeCombatOperation>> preconditions = new();

        [ShowInInspector, ReadOnly, PropertyOrder(-7)]
        private List<IAction<MeleeCombatOperation>> startActions = new();

        [ShowInInspector, ReadOnly, PropertyOrder(-6)]
        private List<IAction<MeleeCombatOperation>> stopActions = new();

        [Title("Methods")]
        [Button]
        public bool CanStartCombat(MeleeCombatOperation operation)
        {
            if (this.IsCombat)
            {
                return false;
            }

            for (int i = 0, count = this.preconditions.Count; i < count; i++)
            {
                var condition = this.preconditions[i];
                if (!condition.IsTrue(operation))
                {
                    return false;
                }
            }

            return true;
        }

        [Button]
        public void StartCombat(MeleeCombatOperation operation)
        {
            if (!this.CanStartCombat(operation))
            {
                return;
            }

            for (int i = 0, count = this.startActions.Count; i < count; i++)
            {
                var action = this.startActions[i];
                action.Do(operation);
            }

            this.CurrentOperation = operation;
            this.OnCombatStarted?.Invoke(operation);
        }

        [Button]
        public void StopCombat()
        {
            if (!this.IsCombat)
            {
                return;
            }

            var operation = this.CurrentOperation;
            for (int i = 0, count = this.stopActions.Count; i < count; i++)
            {
                var action = this.stopActions[i];
                action.Do(operation);
            }

            this.CurrentOperation = default;
            this.OnCombatStopped?.Invoke(operation);
        }
        
        public void AddPreconditions(params ICondition<MeleeCombatOperation>[] conditions)
        {
            this.preconditions.AddRange(conditions);
        }

        public void AddPreconditions(IEnumerable<ICondition<MeleeCombatOperation>> conditions)
        {
            this.preconditions.AddRange(conditions);
        }

        public void AddPreconditon(ICondition<MeleeCombatOperation> condition)
        {
            this.preconditions.Add(condition);
        }

        public void AddStartActions(IEnumerable<IAction<MeleeCombatOperation>> actions)
        {
            this.startActions.AddRange(actions);
        }

        public void AddStartAction(IAction<MeleeCombatOperation> action)
        {
            this.startActions.Add(action);
        }

        public void AddStopActions(IEnumerable<IAction<MeleeCombatOperation>> actions)
        {
            this.stopActions.AddRange(actions);
        }

        public void AddStopAction(IAction<MeleeCombatOperation> action)
        {
            this.stopActions.Add(action);
        }
    }
}