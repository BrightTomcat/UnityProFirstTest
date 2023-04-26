using Game.GameEngine.Mechanics;

namespace Game.Gameplay.Player
{
    public sealed class HarvestResourceAction_AddResourcesToInterface : IHarvestResourceAction
    {
        private readonly ResourcePanelAnimator_AddJumpedResources resourceAnimator;

        public HarvestResourceAction_AddResourcesToInterface(ResourcePanelAnimator_AddJumpedResources animator)
        {
            this.resourceAnimator = animator;
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
            var resourcePosition = operation.targetResource.Get<IComponent_GetPosition>().Position;
            var resourceType = operation.resourceType;
            var resourceAmount = operation.resourceCount;
            this.resourceAnimator.PlayIncomeFromWorld(resourcePosition, resourceType, resourceAmount);
        }
    }
}