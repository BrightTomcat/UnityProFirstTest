using System.Collections.Generic;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy UI Module")]
    public sealed class UIModule : MonoModule
    {
        [SerializeField]
        private HitPointsBar hitPointsView;

        [ShowInInspector, ReadOnly]
        private readonly HitPointsBarAdapter hitPointsViewAdapter = new();

        public override IEnumerable<IMonoComponent> ProvideMonoComponents()
        {
            yield return this.hitPointsViewAdapter;
        }

        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<CoreModule>();
            this.hitPointsViewAdapter.Construct(coreModule.lifeModule.hitPointsEngine, this.hitPointsView);
        }
    }
}