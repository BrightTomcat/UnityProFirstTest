using Elementary;
using MonoOptimization;

namespace Game.GameEngine.Mechanics
{
    public abstract class EventMechanics : IEnableComponent, IDisableComponent
    {
        public IEmitter emitter;

        void IEnableComponent.OnEnable()
        {
            this.emitter.OnEvent += this.OnEvent;
        }

        void IDisableComponent.OnDisable()
        {
            this.emitter.OnEvent -= this.OnEvent;
        }

        protected abstract void OnEvent();
    }
}