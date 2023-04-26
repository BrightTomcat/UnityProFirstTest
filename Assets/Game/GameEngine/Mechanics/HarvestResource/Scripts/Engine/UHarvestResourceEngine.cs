using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Harvest Resource Engine")]
    public sealed class UHarvestResourceEngine : MonoBehaviour
    {
        public event Action<HarvestResourceOperation> OnHarvestStarted;

        public event Action<HarvestResourceOperation> OnHarvestStopped;

        [PropertyOrder(-10)]
        [ReadOnly]
        [ShowInInspector]
        public bool IsHarvesting
        {
            get { return this.CurrentOperation != null; }
        }

        [PropertyOrder(-9)]
        [ReadOnly]
        [ShowInInspector]
        public HarvestResourceOperation CurrentOperation { get; private set; }

        [PropertySpace]
        [SerializeField]
        private UHarvestResourceCondition[] preconditions;

        [SerializeField]
        private UHarvestResourceAction[] startActions;

        [SerializeField]
        private UHarvestResourceAction[] stopActions;

        public bool CanStartHarvest(HarvestResourceOperation operation)
        {
            if (this.IsHarvesting)
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

        public void StartHarvest(HarvestResourceOperation operation)
        {
            if (!this.CanStartHarvest(operation))
            {
                Debug.LogWarning("Can't start harvest!", this);
                return;
            }

            for (int i = 0, count = this.startActions.Length; i < count; i++)
            {
                var action = this.startActions[i];
                action.Do(operation);
            }

            this.CurrentOperation = operation;
            this.OnHarvestStarted?.Invoke(operation);
        }

        public void StopHarvest()
        {
            if (!this.IsHarvesting)
            {
                Debug.LogWarning("Harvest is not started!", this);
                return;
            }

            var operation = this.CurrentOperation;
            for (int i = 0, count = this.stopActions.Length; i < count; i++)
            {
                var action = this.stopActions[i];
                action.Do(operation);
            }

            this.CurrentOperation = null;
            this.OnHarvestStopped?.Invoke(operation);
        }
    }
}