using System;
using Elementary;

namespace Game.GameEngine.Animation
{
    [Serializable]
    public sealed class AnimatorState_ApplyRootMotion : State
    {
        private AnimatorSystem system;

        public void Construct(AnimatorSystem system)
        {
            this.system = system;
        }

        public override void Enter()
        {
            this.system.ApplyRootMotion();
        }
    }
}