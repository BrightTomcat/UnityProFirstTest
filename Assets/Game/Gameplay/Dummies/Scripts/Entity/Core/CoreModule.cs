using Elementary;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Dummies
{
    [AddComponentMenu("Gameplay/Dummies/Dummy Core Module")]
    public sealed class CoreModule : MonoModule
    {
        [Space]
        [SerializeField]
        public TransformEngine transformEngine = new();

        [Space]
        [SerializeField]
        public TakeDamageEngine takeDamageEngine = new();

        [Space]
        [SerializeField]
        public HitPointsEngine hitPointsEngine = new();

        [Space]
        [SerializeField]
        public Emitter<DestroyArgs> destroyReceiver = new();

        public override void Construct(MonoContextModular context)
        {
            this.takeDamageEngine.Construct(this.hitPointsEngine, this.destroyReceiver);

            var configModule = context.GetModule<ConfigModule>();
            var config = configModule.dummyConfig;
            this.ConstructHitPoints(config);
        }

        private void ConstructHitPoints(ScriptableDummy config)
        {
            var hitPoints = config.hitPoints;
            this.hitPointsEngine.MaxHitPoints = hitPoints;
            this.hitPointsEngine.CurrentHitPoints = hitPoints;
        }
    }
}