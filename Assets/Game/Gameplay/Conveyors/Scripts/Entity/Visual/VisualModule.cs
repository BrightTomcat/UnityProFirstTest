using System.Collections.Generic;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Conveyors
{
    [AddComponentMenu("Gameplay/Conveyors/Conveyor Visual Module")]
    public sealed class VisualModule : MonoModule
    {
        [SerializeField]
        private ConveyorVisual conveyorView;

        private readonly ConveyorVisualAdapter conveyorViewAdapter = new();

        [SerializeField]
        private ZoneVisual loadZoneView;

        private readonly ZoneVisualAdapter loadZoneViewAdapter = new();

        [SerializeField]
        private ZoneVisual unloadZoneView;

        private readonly ZoneVisualAdapter unloadZoneViewAdapter = new();

        public override IEnumerable<IMonoComponent> ProvideMonoComponents()
        {
            yield return this.conveyorViewAdapter;
            yield return this.loadZoneViewAdapter;
            yield return this.unloadZoneViewAdapter;
        }

        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<CoreModule>();
            this.conveyorViewAdapter.Construct(coreModule.workTimer, this.conveyorView);
            this.loadZoneViewAdapter.Construct(coreModule.loadStorage, this.loadZoneView);
            this.unloadZoneViewAdapter.Construct(coreModule.unloadStorage, this.unloadZoneView);
        }
    }
}