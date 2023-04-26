using Entities;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;
using UnityEngine;

namespace Game.Meta
{
    public sealed class EffectBooster : Booster
    {
        private readonly EffectBoosterConfig config;

        [GameInject]
        private IHeroService heroService;

        public EffectBooster(EffectBoosterConfig config, MonoBehaviour context) : base(config, context)
        {
            this.config = config;
        }

        protected override void OnStart()
        {
            var heroComponent = this.heroService.GetHero().Get<IComponent_Effector>();
            heroComponent.AddEffect(this.config.effect);
        }

        protected override void OnStop()
        {
            var heroComponent = this.heroService.GetHero().Get<IComponent_Effector>();
            heroComponent.RemoveEffect(this.config.effect);
        }
    }
}