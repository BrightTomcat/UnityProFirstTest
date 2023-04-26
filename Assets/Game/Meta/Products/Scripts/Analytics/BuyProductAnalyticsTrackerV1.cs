using Game.GameEngine.Products;
using Game.Gameplay.Player;
using GameSystem;
using UnityEngine;

namespace Game.Meta
{
    public sealed class BuyProductAnalyticsTrackerV1 :
        IGameReadyElement,
        IGameFinishElement
    {
        [GameInject]
        private ProductBuyer buyManager;

        [GameInject]
        private MoneyAnalyticsSupplier moneySupplier;

        void IGameReadyElement.ReadyGame()
        {
            this.buyManager.OnCompleted += this.OnBuyProduct;
        }

        void IGameFinishElement.FinishGame()
        {
            this.buyManager.OnCompleted -= this.OnBuyProduct;
        }

        private void OnBuyProduct(Product product)
        {
            BuyProductAnalytics.LogProductBought(
                product,
                previousMoney: this.moneySupplier.PreviousMoney,
                currentMoney: this.moneySupplier.CurrentMoney
            );
        }
    }
}