using Elementary;
using MonoOptimization;

namespace Game.GameEngine.Mechanics
{
    public abstract class DestroyMechanics :
        IEnableComponent,
        IDisableComponent
    {
        public IEmitter<DestroyArgs> emitter;

        void IEnableComponent.OnEnable()
        {
            this.emitter.OnEvent += this.Destroy;
        }

        void IDisableComponent.OnDisable()
        {
            this.emitter.OnEvent -= this.Destroy;
        }

        protected abstract void Destroy(DestroyArgs destroyArgs);
    }
}