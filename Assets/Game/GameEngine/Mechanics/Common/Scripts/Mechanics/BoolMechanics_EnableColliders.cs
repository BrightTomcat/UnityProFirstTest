using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class BoolMechanics_EnableColliders : BoolMechanics
    {
        [Space, SerializeField]
        public Collider[] colliders;

        protected override void SetValue(bool isEnable)
        {
            for (int i = 0, count = this.colliders.Length; i < count; i++)
            {
                var collider = this.colliders[i];
                collider.enabled = isEnable;
            }
        }
    }
}