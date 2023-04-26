using System;
using Elementary;
using MonoOptimization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.ResourceObjects
{
    [Serializable]
    public sealed class LifeModule
    {
        [SerializeField, Space]
        public Emitter destroyEvent = new();

        [SerializeField, Space]
        private Emitter respawnEvent = new();

        [SerializeField, Space]
        public BoolVariable activeVariable = new();

        [SerializeField, Space]
        public Countdown respawnTimer = new();

        [MonoComponent]
        [ShowInInspector, ReadOnly]
        public RespawnMechanics respawnMechanics = new();

        [Resolve]
        private void ConstructActive()
        {
            this.activeVariable.Current = true;

            this.destroyEvent.AddListener(this.activeVariable.SetFalseByAction());
            this.respawnEvent.AddListener(this.activeVariable.SetTrueByAction());
        }

        [Resolve]
        private void ConstructRespawnMechanics(MonoContextModular context)
        {
            var configModule = context.GetModule<ConfigModule>();
            this.respawnTimer.Duration = configModule.info.respawnTime;
            this.respawnTimer.CoroutineDispatcher = context;
            this.respawnMechanics.Construct(this.destroyEvent, this.respawnTimer, this.respawnEvent);
        }
    }
}