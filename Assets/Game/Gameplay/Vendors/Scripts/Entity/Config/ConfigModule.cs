using Game.GameEngine.GameResources;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Vendors
{
    [AddComponentMenu("Gameplay/Vendors/Vendor Config Module")]
    public sealed class ConfigModule : MonoModule
    {
        [SerializeField]
        public ScriptableVendor vendorConfig;

        [SerializeField]
        public ResourceInfoCatalog resourceCatalog;
    }
}