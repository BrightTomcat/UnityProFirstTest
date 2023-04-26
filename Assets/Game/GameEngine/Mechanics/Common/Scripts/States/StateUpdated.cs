using Elementary;
using MonoOptimization;

namespace Game.GameEngine.Mechanics
{
    public abstract class StateUpdated : State, IUpdateComponent
    {
        private bool enabled;

        public override void Enter()
        {
            this.enabled = true;
        }

        public override void Exit()
        {
            this.enabled = false;
        }

        void IUpdateComponent.Update(float deltaTime)
        {
            if (this.enabled)
            {
                this.Update(deltaTime);
            }
        }

        protected abstract void Update(float deltaTime);
    }
}