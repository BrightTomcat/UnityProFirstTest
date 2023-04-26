using Elementary;
using MonoOptimization;

namespace Game.GameEngine.Mechanics
{
    public abstract class TakeDamageMechanics : IEnableComponent, IDisableComponent
    {
        public IEmitter<TakeDamageArgs> emitter;

        void IEnableComponent.OnEnable()
        {
            this.emitter.OnEvent += this.OnDamageTaken;
        }

        void IDisableComponent.OnDisable()
        {
            this.emitter.OnEvent -= this.OnDamageTaken;
        }

        protected abstract void OnDamageTaken(TakeDamageArgs damageArgs);
    }
}