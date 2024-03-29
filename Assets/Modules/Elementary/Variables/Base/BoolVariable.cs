using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    [Serializable]
    public sealed class BoolVariable : IVariable<bool>
    {
        public event Action<bool> OnValueChanged;

        public bool Current
        {
            get { return this.value; }
            set { this.SetValue(value); }
        }

        private readonly List<IAction<bool>> listeners = new();

        [OnValueChanged("SetValue")]
        [SerializeField]
        private bool value;

        public void AddListener(IAction<bool> listener)
        {
            this.listeners.Add(listener);
        }

        public void RemoveListener(IAction<bool> listener)
        {
            this.listeners.Remove(listener);
        }

        private void SetValue(bool value)
        {
            for (int i = 0, count = this.listeners.Count; i < count; i++)
            {
                var listener = this.listeners[i];
                listener.Do(value);
            }

            this.value = value;
            this.OnValueChanged?.Invoke(value);
        }
    }
}