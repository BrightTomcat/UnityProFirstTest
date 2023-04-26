using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class BoolMechanics_EnableBehaviours : BoolMechanics
    {
        [Space, SerializeField]
        public Behaviour[] behaviours;

        protected override void SetValue(bool isEnable)
        {
            for (int i = 0, count = this.behaviours.Length; i < count; i++)
            {
                var behaviour = this.behaviours[i];
                behaviour.enabled = isEnable;
            }
        }
    }
}