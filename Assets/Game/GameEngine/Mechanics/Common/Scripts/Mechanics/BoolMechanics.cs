using Elementary;
using MonoOptimization;

namespace Game.GameEngine.Mechanics
{
    public abstract class BoolMechanics :
        IAwakeComponent,
        IEnableComponent,
        IDisableComponent
    {
        public IVariable<bool> variable;

        void IAwakeComponent.Awake()
        {
            this.SetValue(this.variable.Current);
        }

        void IEnableComponent.OnEnable()
        {
            this.variable.OnValueChanged += this.SetValue;
        }

        void IDisableComponent.OnDisable()
        {
            this.variable.OnValueChanged -= this.SetValue;
        }

        protected abstract void SetValue(bool isEnable);
    }
}