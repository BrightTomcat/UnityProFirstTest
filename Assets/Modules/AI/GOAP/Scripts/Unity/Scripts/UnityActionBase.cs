using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AI.GOAP
{
    public abstract class UnityActionBase : MonoBehaviour, IAction
    {
        public virtual string Name
        {
            get { return this.name; }
        }

        public Parameter[] RequiredState
        {
            get { return this.requiredState; }
        }

        public Parameter[] SatisfiedState
        {
            get { return this.satisfiedState; }
        }

        [Space, SerializeField]
        protected Parameter[] requiredState;

        [SerializeField]
        protected Parameter[] satisfiedState;

        public abstract int EvaluateCost();

        public abstract bool IsValid();

        public override string ToString()
        {
            return $"{this.name}";
        }
    }
}