using Game.App;
using Services;

namespace Game.Meta
{
    public sealed class UpgradesMediator :
        IGameLoadDataListener,
        IGameSaveDataListener
    {
        [ServiceInject]
        private UpgradesRepository repository;

        [ServiceInject]
        private UpgradesAssetSupplier assetSupplier;

        private UpgradesManager upgradesManager;

        void IGameLoadDataListener.OnLoadData(GameManager gameManager)
        {
            this.upgradesManager = gameManager.GetService<UpgradesManager>();

            if (!this.repository.LoadUpgrades(out var upgradesData))
            {
                upgradesData = this.LoadInitialUpgrades();
            }

            this.SetupUpgrades(upgradesData);
        }

        void IGameSaveDataListener.OnSaveData(GameSaveReason reason)
        {
            this.SaveUpgrades();
        }

        private UpgradeData[] LoadInitialUpgrades()
        {
            var configs = this.assetSupplier.GetAllUpgrades();
            return UpgradesConverter.ToInitialDataArray(configs);
        }

        private void SetupUpgrades(UpgradeData[] upgradesData)
        {
            for (int i = 0, count = upgradesData.Length; i < count; i++)
            {
                var data = upgradesData[i];
                var upgrade = this.upgradesManager.GetUpgrade(data.id);
                upgrade.SetupLevel(data.level);
            }
        }

        private void SaveUpgrades()
        {
            var upgrades = this.upgradesManager.GetAllUpgrades();
            var dataSet = UpgradesConverter.ToDataArray(upgrades);
            this.repository.SaveUpgrades(dataSet);
        }
    }
}