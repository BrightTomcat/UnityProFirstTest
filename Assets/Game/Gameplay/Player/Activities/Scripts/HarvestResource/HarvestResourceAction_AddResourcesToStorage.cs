using Game.GameEngine.Mechanics;

namespace Game.Gameplay.Player
{
    public sealed class HarvestResourceAction_AddResourcesToStorage : IHarvestResourceAction 
    {
        private readonly ResourceStorage resourceStorage;

        public HarvestResourceAction_AddResourcesToStorage(ResourceStorage resourceStorage)
        {
            this.resourceStorage = resourceStorage;
        }

        public void Do(HarvestResourceOperation operation)
        {
            if (operation.isCompleted)
            {
                this.AddResources(operation);
            }
        }

        private void AddResources(HarvestResourceOperation operation)
        {
            var resourceType = operation.resourceType;
            var resourceAmount = operation.resourceCount;
            this.resourceStorage.AddResource(resourceType, resourceAmount);
        }
    }
}