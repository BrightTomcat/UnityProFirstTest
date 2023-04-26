using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Melee Combat/Melee Combat Engine")]
    public sealed class UMeleeCombatEngine : MonoBehaviour, IMeleeCombatEngine
    {
        public event Action<MeleeCombatOperation> OnCombatStarted;

        public event Action<MeleeCombatOperation> OnCombatStopped;

        [PropertySpace]
        [PropertyOrder(-10)]
        [ReadOnly]
        [ShowInInspector]
        public bool IsCombat
        {
            get { return this.CurrentOperation != null; }
        }

        [PropertyOrder(-9)]
        [ReadOnly]
        [ShowInInspector]
        public MeleeCombatOperation CurrentOperation { get; private set; }

        [SerializeField]
        private UMeleeCombatCondition[] preconditions;

        [SerializeField]
        private UMeleeCombatAction[] startActions;
        
        [SerializeField]
        private UMeleeCombatAction[] stopActions;
        
        public bool CanStartCombat(MeleeCombatOperation operation)
        {
            if (this.IsCombat)
            {
                return false;
            }
            
            for (int i = 0, count = this.preconditions.Length; i < count; i++)
            {
                var condition = this.preconditions[i];
                if (!condition.IsTrue(operation))
                {
                    return false;
                }
            }

            return true;
        }

        public void StartCombat(MeleeCombatOperation operation)
        {
            if (!this.CanStartCombat(operation))
            {
                Debug.LogWarning("Can't start combat!", this);
                return;
            }

            for (int i = 0, count = this.startActions.Length; i < count; i++)
            {
                var action = this.startActions[i];
                action.Do(operation);
            }

            this.CurrentOperation = operation;
            this.OnCombatStarted?.Invoke(operation);
        }

        public void StopCombat()
        {
            if (!this.IsCombat)
            {
                Debug.LogWarning("Combat is not started!", this);
                return;
            }

            var operation = this.CurrentOperation;
            for (int i = 0, count = this.stopActions.Length; i < count; i++)
            {
                var action = this.stopActions[i];
                action.Do(operation);
            }

            this.CurrentOperation = default;
            this.OnCombatStopped?.Invoke(operation);
        }
    }
}