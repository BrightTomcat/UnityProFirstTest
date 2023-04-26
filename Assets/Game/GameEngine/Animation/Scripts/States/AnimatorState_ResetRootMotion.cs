using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Animation
{
    [Serializable]
    public sealed class AnimatorState_ResetRootMotion : State
    {
        private AnimatorSystem system;

        [SerializeField]
        private bool resetPosition = true;

        [SerializeField]
        private bool resetRotation = true;

        public void Construct(AnimatorSystem system)
        {
            this.system = system;
        }

        public override void Enter()
        {
            this.system.ResetRootMotion(
                resetPosition: this.resetPosition,
                resetRotation: this.resetRotation
            );
        }
    }
}