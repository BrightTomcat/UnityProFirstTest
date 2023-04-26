using Game.GameEngine.Products;
using Game.Gameplay.Player;
using GameSystem;
using UnityEngine;

namespace Game.Meta
{
    public sealed class BuyProductAnalyticsTrackerV2 : MonoBehaviour, 
        IGameReadyElement,
        IGameFinishElement
    {
        [GameInject]
        private ProductBuyer buyManager;

        [GameInject]
        private MoneyStorage moneyStorage;

        private int previousMoney;

        void IGameReadyElement.ReadyGame()
        {
            this.buyManager.OnStarted += this.OnStartBuy;
            this.buyManager.OnCompleted += this.OnFinishBuy;
        }

        void IGameFinishElement.FinishGame()
        {
            this.buyManager.OnStarted -= this.OnStartBuy;
            this.buyManager.OnCompleted -= this.OnFinishBuy;
        }

        private void OnStartBuy(Product product)
        {
            this.previousMoney = this.moneyStorage.Money;
        }

        private void OnFinishBuy(Product product)
        {
            var currentMoney = this.moneyStorage.Money;
            BuyProductAnalytics.LogProductBought(product, this.previousMoney, currentMoney);
        }
    }
}