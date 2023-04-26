namespace Game.Gameplay.Vendors
{
    public sealed class Component_CompleteDeal : IComponent_CompleteDeal
    {
        private readonly VendorVisual visual;

        public Component_CompleteDeal(VendorVisual visual)
        {
            this.visual = visual;
        }

        public void NotifyAboutCompleted()
        {
            visual.NotifyAboutDealCompleted();
        }
    }
}