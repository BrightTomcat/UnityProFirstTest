using System.Collections.Generic;
using Game.GameEngine;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Vendors
{
    [AddComponentMenu("Gameplay/Vendors/Vendor UI Module")]
    public sealed class UIModule : MonoModule
    {
        [SerializeField]
        private InfoWidget infoView;

        [SerializeField]
        private _UIParryAnimator infoViewAnimator = new();

        public override IEnumerable<IMonoComponent> ProvideMonoComponents()
        {
            yield return this.infoViewAnimator;
        }

        public override void Construct(MonoContextModular context)
        {
            var configModule = context.GetModule<ConfigModule>();
            var vendorConfig = configModule.vendorConfig;
            var resourceCatalog = configModule.resourceCatalog;
            
            var resourceType = vendorConfig.resourceType;
            var pricePerResource = vendorConfig.pricePerOne;
            
            var resourceIcon = resourceCatalog.FindResource(resourceType).icon;
            this.infoView.SetPrice(pricePerResource.ToString());
            this.infoView.SetIcon(resourceIcon);
        }
    }
}