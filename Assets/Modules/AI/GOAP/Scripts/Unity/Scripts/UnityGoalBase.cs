using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AI.GOAP
{
    public abstract class UnityGoalBase : MonoBehaviour, IGoal
    {
        public virtual string Name
        {
            get { return this.name; }
        }

        public Parameter[] DesiredState
        {
            get { return this.desiredState; }
        }

        [Space, SerializeField]
        protected Parameter[] desiredState;

        public abstract int EvaluatePriority();

        public abstract bool IsValid();
        
        public override string ToString()
        {
            return $"{this.name}";
        }
    }
}