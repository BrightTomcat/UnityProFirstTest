using Elementary;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Conveyors
{
    public sealed class ConveyorVisualAdapter :
        IEnableComponent,
        IDisableComponent
    {
        private ITimer workTimer;

        private ConveyorVisual conveyor;

        public void Construct(ITimer workTimer, ConveyorVisual conveyor)
        {
            this.workTimer = workTimer;
            this.conveyor = conveyor;
        }

        void IEnableComponent.OnEnable()
        {
            this.workTimer.OnStarted += this.OnStartWork;
            this.workTimer.OnFinished += this.OnFinishWork;
        }

        void IDisableComponent.OnDisable()
        {
            this.workTimer.OnStarted -= this.OnStartWork;
            this.workTimer.OnFinished -= this.OnFinishWork;
        }

        private void OnStartWork()
        {
            this.conveyor.Play();
        }

        private void OnFinishWork()
        {
            this.conveyor.Stop();
        }
    }
}