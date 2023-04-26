using System.Collections.Generic;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Conveyors
{
    [AddComponentMenu("Gameplay/Conveyors/Conveyor UI Module")]
    public sealed class UIModule : MonoModule
    {
        [SerializeField]
        private InfoWidget infoView;

        private readonly InfoWidgetAdapter infoViewAdapter = new();

        public override IEnumerable<IMonoComponent> ProvideMonoComponents()
        {
            yield return this.infoViewAdapter;
        }

        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<CoreModule>();
            this.infoViewAdapter.Construct(coreModule.workTimer, this.infoView);

            var configModule = context.GetModule<ConfigModule>();
            var conveyorConfig = configModule.conveyourConfig;
            var resourceCatalog = configModule.resourceCatalog;

            var inputType = conveyorConfig.inputResourceType;
            var inputIcon = resourceCatalog.FindResource(inputType).icon;
            this.infoView.SetInputIcon(inputIcon);
            
            var outputType = conveyorConfig.outputResourceType;
            var outputIcon = resourceCatalog.FindResource(outputType).icon;
            this.infoView.SetOutputIcon(outputIcon);
        }
    }
}