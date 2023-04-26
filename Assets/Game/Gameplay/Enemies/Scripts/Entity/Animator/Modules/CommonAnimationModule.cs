using System;
using Game.GameEngine.Animation;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class CommonAnimationModule
    {
        [SerializeField]
        public AnimatorState_ApplyRootMotion applyRootMotionState = new();

        [SerializeField]
        public AnimatorState_ResetRootMotion resetRootMotionState = new();

        [Resolve]
        private void Construct(AnimatorModule animModule)
        {
            var animatorSystem = animModule.animatorSystem;
            this.applyRootMotionState.Construct(animatorSystem);
            this.resetRootMotionState.Construct(animatorSystem);
        }
    }
}