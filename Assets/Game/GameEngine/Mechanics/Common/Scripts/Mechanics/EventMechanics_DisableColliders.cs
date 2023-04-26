using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class EventMechanics_DisableColliders : EventMechanics
    {
        [Space, SerializeField]
        public Collider[] colliders;

        protected override void OnEvent()
        {
            for (int i = 0, count = this.colliders.Length; i < count; i++)
            {
                var collider = this.colliders[i];
                collider.enabled = false;
            }
        }
    }
}