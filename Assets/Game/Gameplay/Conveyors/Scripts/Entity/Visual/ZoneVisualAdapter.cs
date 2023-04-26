using Elementary;
using MonoOptimization;

namespace Game.Gameplay.Conveyors
{
    public sealed class ZoneVisualAdapter :
        IAwakeComponent,
        IEnableComponent,
        IDisableComponent
    {
        private IVariableLimited<int> storage;

        private ZoneVisual visualZone;

        public void Construct(IVariableLimited<int> storage, ZoneVisual visualZone)
        {
            this.storage = storage;
            this.visualZone = visualZone;
        }

        void IAwakeComponent.Awake()
        {
            this.visualZone.SetupItems(this.storage.Current);
        }

        void IEnableComponent.OnEnable()
        {
            this.storage.OnValueChanged += this.OnItemsChanged;
        }

        void IDisableComponent.OnDisable()
        {
            this.storage.OnValueChanged -= this.OnItemsChanged;
        }

        private void OnItemsChanged(int count)
        {
            this.visualZone.SetupItems(count);
        }
    }
}