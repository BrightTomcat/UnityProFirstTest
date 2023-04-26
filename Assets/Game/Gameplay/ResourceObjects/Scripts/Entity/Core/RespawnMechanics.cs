using System;
using Elementary;
using MonoOptimization;

namespace Game.Gameplay.ResourceObjects
{
    [Serializable]
    public sealed class RespawnMechanics :
        IEnableComponent,
        IDisableComponent
    {
        private IEmitter destroyEvent;

        private ICountdown countdown;

        private IEmitter respawnEvent;

        public void Construct(
            IEmitter destroyEmitter,
            ICountdown timer,
            IEmitter respawnEvent
        )
        {
            this.destroyEvent = destroyEmitter;
            this.countdown = timer;
            this.respawnEvent = respawnEvent;
        }

        void IEnableComponent.OnEnable()
        {
            this.destroyEvent.OnEvent += this.OnDeactivate;
            this.countdown.OnEnded += this.OnActivate;
        }

        void IDisableComponent.OnDisable()
        {
            this.destroyEvent.OnEvent -= this.OnDeactivate;
            this.countdown.OnEnded -= this.OnActivate;
        }

        private void OnDeactivate()
        {
            this.countdown.ResetTime();
            this.countdown.Play();
        }

        private void OnActivate()
        {
            this.respawnEvent.Call();
        }
    }
}