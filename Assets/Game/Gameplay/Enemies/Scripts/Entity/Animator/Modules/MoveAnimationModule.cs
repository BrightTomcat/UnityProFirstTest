using System;
using Elementary;
using MonoOptimization;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class MoveAnimationModule
    {
        private StateComposite state = new();

        [Resolve]
        private void Construct(CommonAnimationModule commonStateModule)
        {
            this.state.AddState(commonStateModule.resetRootMotionState);
        }

        public IState GetState()
        {
            return this.state;
        }
    }
}