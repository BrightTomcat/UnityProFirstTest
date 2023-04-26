using Elementary;
using Game.GameEngine.Mechanics;
using MonoOptimization;

namespace Game.Gameplay.Conveyors
{
    public sealed class WorkMechanics :
        IEnableComponent,
        IDisableComponent,
        IFixedUpdateComponent
    {
        private IVariable<bool> isEnable;

        private IVariableLimited<int> loadStorage;

        private IVariableLimited<int> unloadStorage;

        private ITimer workTimer;

        public void Construct(
            IVariable<bool> isEnable,
            IVariableLimited<int> loadStorage,
            IVariableLimited<int> unloadStorage,
            ITimer workTimer
        )
        {
            this.isEnable = isEnable;
            this.loadStorage = loadStorage;
            this.unloadStorage = unloadStorage;
            this.workTimer = workTimer;
        }

        void IEnableComponent.OnEnable()
        {
            this.workTimer.OnFinished += this.OnWorkFinished;
        }

        void IDisableComponent.OnDisable()
        {
            this.workTimer.OnFinished -= this.OnWorkFinished;
        }

        void IFixedUpdateComponent.FixedUpdate(float deltaTime)
        {
            if (!this.isEnable.Current)
            {
                return;
            }
            
            if (this.CanStartWork())
            {
                this.StartWork();
            }
        }

        private bool CanStartWork()
        {
            if (this.workTimer.IsPlaying)
            {
                return false;
            }

            if (this.loadStorage.Current == 0)
            {
                return false;
            }

            if (this.unloadStorage.IsLimit)
            {
                return false;
            }

            return true;
        }

        private void StartWork()
        {
            this.loadStorage.Current--;
            this.workTimer.ResetTime();
            this.workTimer.Play();
        }

        private void OnWorkFinished()
        {
            this.unloadStorage.Current++;
        }
    }
}