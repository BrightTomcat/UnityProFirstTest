using Game.App;
using Services;

namespace Game.Gameplay.Player
{
    public sealed class MoneyMediator :
        IGameLoadDataListener,
        IGameSaveDataListener
    {
        private MoneyRepository repository;

        private MoneyStorage storage;

        [ServiceInject]
        public void Construct(MoneyRepository repository)
        {
            this.repository = repository;
        }
        
        void IGameLoadDataListener.OnLoadData(GameManager gameManager)
        {
            this.storage = gameManager.GetService<MoneyStorage>();
            this.LoadMoney();
        }

        void IGameSaveDataListener.OnSaveData(GameSaveReason reason)
        {
            this.repository.SaveMoney(this.storage.Money);
        }
        
        private void LoadMoney()
        {
            if (!this.repository.LoadMoney(out var money))
            {
                var config = MoneyStorageConfig.LoadAsset();
                money = config.InitialMoney;
            }

            this.storage.SetupMoney(money);
        }
    }
}