using Game.Gameplay.Player;
using GameSystem;
using Game.GameEngine;
using Game.Gameplay;
using UnityEngine;

namespace Game.Meta
{
    public sealed class IncomeBooster : Booster
    {
        [GameInject]
        private VendorInteractor vendorInteractor;

        private readonly IncomeBoosterConfig config;

        public IncomeBooster(IncomeBoosterConfig config, MonoBehaviour context) : base(config, context)
        {
            this.config = config;
        }

        protected override void OnStart()
        {
            this.vendorInteractor.IncomeMultiplier *= this.config.incomeCoefficient;
        }

        protected override void OnStop()
        {
            this.vendorInteractor.IncomeMultiplier /= this.config.incomeCoefficient; 
        }
    }
}