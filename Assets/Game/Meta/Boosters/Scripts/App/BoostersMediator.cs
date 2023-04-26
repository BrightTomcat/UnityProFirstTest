using Game.App;
using Services;

namespace Game.Meta
{
    public sealed class BoostersMediator :
        IGameLoadDataListener,
        IGameSaveDataListener
    {
        [ServiceInject]
        private BoostersRepository repository;

        [ServiceInject]
        private BoostersAssetSupplier assetSupplier;

        private BoostersManager boostersManager;

        void IGameLoadDataListener.OnLoadData(GameManager gameManager)
        {
            this.boostersManager = gameManager.GetService<BoostersManager>();
            if (this.repository.LoadBoosters(out var boostersData))
            {
                this.SetupBoosters(boostersData);
            }
        }

        void IGameSaveDataListener.OnSaveData(GameSaveReason reason)
        {
            this.SaveBoosters();
        }

        private void SetupBoosters(BoosterData[] boostersData)
        {
            for (int i = 0, count = boostersData.Length; i < count; i++)
            {
                var data = boostersData[i];
                var config = this.assetSupplier.GetBooster(data.id);
                var booster = this.boostersManager.SetupBooster(config);
                booster.RemainingTime = data.remainingTime;
            }
        }

        private void SaveBoosters()
        {
            var boosters = this.boostersManager.GetActiveBoosters();
            var count = boosters.Length;
            var boostersData = new BoosterData[count];

            for (var i = 0; i < count; i++)
            {
                var booster = boosters[i];
                var data = new BoosterData
                {
                    id = booster.Id,
                    remainingTime = booster.RemainingTime
                };

                boostersData[i] = data;
            }

            this.repository.SaveBoosters(boostersData);
        }
    }
}