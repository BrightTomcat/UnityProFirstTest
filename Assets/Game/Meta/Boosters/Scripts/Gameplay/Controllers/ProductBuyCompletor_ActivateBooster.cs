using Game.GameEngine.Products;

namespace Game.Meta
{
    public sealed class ProductBuyCompletor_ActivateBooster : IProductBuyCompletor
    {
        private readonly BoostersManager boostersManager;

        public ProductBuyCompletor_ActivateBooster(BoostersManager boostersManager)
        {
            this.boostersManager = boostersManager;
        }

        void IProductBuyCompletor.CompleteBuy(Product product)
        {
            if (product.TryGetComponent(out IComponent_BoosterInfo component))
            {
                this.boostersManager.LaunchBooster(component.BoosterInfo);
            }
        }
    }
}