using Game.App;
using Game.GameEngine.Products;
using Game.Gameplay.Player;
using UnityEngine;

namespace Game.Meta
{
    public sealed class BuyProductAnalytics : MonoBehaviour
    {
        public static void LogProductBought(
            Product product,
            int previousMoney,
            int currentMoney
        )
        {
            const string eventName = "product_bought";
            AnalyticsManager.LogEvent(eventName,
                ProductIdParameter(product),
                MoneyAnalytics.PreviousMoneyParameter(previousMoney),
                MoneyAnalytics.CurrentMoneyParameter(currentMoney)
            );
        }

        public static AnalyticsParameter ProductIdParameter(Product product)
        {
            const string name = "product_id";
            return new AnalyticsParameter(name, product.Id);
        }
    }
}