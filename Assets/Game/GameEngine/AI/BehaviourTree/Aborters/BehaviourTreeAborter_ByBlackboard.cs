using System;
using System.Collections.Generic;
using AI.Blackboards;
using AI.BTree;
using MonoOptimization;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [Serializable]
    public sealed class BehaviourTreeAborter_ByBlackboard :
        IEnableComponent,
        IDisableComponent,
        IUpdateComponent
    {
        private IBehaviourTree behaviourTree;

        private IBlackboard blackboard;

        private bool abortRequired;
        
        [BlackboardKey]
        [SerializeField]
        private List<string> blackboardKeys;

        public void Construct(IBehaviourTree behaviourTree, IBlackboard blackboard)
        {
            this.behaviourTree = behaviourTree;
            this.blackboard = blackboard;
        }

        public void SetBlackboardKeys(params string[] keys)
        {
            this.blackboardKeys = new List<string>(keys);
        }

        void IEnableComponent.OnEnable()
        {
            this.blackboard.OnVariableAdded += this.OnVariableChanged;
            this.blackboard.OnVariableRemoved += this.OnVariableChanged;
        }

        void IUpdateComponent.Update(float deltaTime)
        {
            if (this.abortRequired)
            {
                this.behaviourTree.Abort();
                this.abortRequired = false;
            }
        }

        void IDisableComponent.OnDisable()
        {
            this.blackboard.OnVariableAdded -= this.OnVariableChanged;
            this.blackboard.OnVariableRemoved -= this.OnVariableChanged;
        }
        
        private void OnVariableChanged(string key, object value)
        {
            if (this.blackboardKeys.Contains(key))
            {
                this.abortRequired = true;
            }
        }
    }
}