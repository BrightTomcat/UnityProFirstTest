using System;
using UnityEngine;

namespace AI.GOAP
{
    [AddComponentMenu("AI/GOAP/World State")]
    [DisallowMultipleComponent]
    public sealed class UnityWorldState : MonoBehaviour, IWorldState
    {
        public event Action<Parameter> OnParameterChanged
        {
            add { this.worldState.OnParameterChanged += value; }
            remove { this.worldState.OnParameterChanged -= value; }
        }

        public event Action<Parameter> OnParameterAdded
        {
            add { this.worldState.OnParameterAdded += value; }
            remove { this.worldState.OnParameterAdded -= value; }
        }

        public event Action<Parameter> OnParameterRemoved
        {
            add { this.worldState.OnParameterRemoved += value; }
            remove { this.worldState.OnParameterRemoved -= value; }
        }

        [SerializeField]
        private WorldState worldState = new();
        
        public bool ContainsParameter(string name)
        {
            return this.worldState.ContainsParameter(name);
        }

        public bool TryGetParameter(string name, out bool value)
        {
            return this.worldState.TryGetParameter(name, out value);
        }
        
        public void ChangeParameter(string name, bool value)
        {
            this.worldState.ChangeParameter(name, value);
        }

        public void AddParameter(string name, bool value)
        {
            this.worldState.AddParameter(name, value);
        }

        public void RemoveParameter(string name)
        {
            this.worldState.RemoveParameter(name);
        }

        public bool GetParameter(string name)
        {
            return this.worldState.GetParameter(name);
        }

        public Parameter[] GetAllParameters()
        {
            return this.worldState.GetAllParameters();
        }
    }
}