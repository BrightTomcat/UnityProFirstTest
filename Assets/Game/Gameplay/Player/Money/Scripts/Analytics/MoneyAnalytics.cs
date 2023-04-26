using Game.App;

namespace Game.Gameplay.Player
{
    public static class MoneyAnalytics
    {
        public static AnalyticsParameter PreviousMoneyParameter(int previousMoney)
        {
            const string name = "previous_money";
            return new AnalyticsParameter(name, previousMoney);
        }

        public static AnalyticsParameter CurrentMoneyParameter(int currentMoney)
        {
            const string name = "current_money";
            return new AnalyticsParameter(name, currentMoney);
        }
    }
}