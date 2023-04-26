using System.Collections.Generic;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;
using Sirenix.OdinInspector;

namespace Game.Gameplay.Player
{
    public sealed class HarvestResourceObserver :
        IGameInitElement,
        IGameReadyElement,
        IGameFinishElement
    {
        private HeroService heroService;

        private IComponent_HarvestResource heroComponent;

        [ShowInInspector, ReadOnly]
        private readonly List<IHarvestResourceAction> startActions = new();

        [ShowInInspector, ReadOnly]
        private readonly List<IHarvestResourceAction> stopActions = new();

        public void Construct(HeroService heroService)
        {
            this.heroService = heroService;
        }

        public void RegisterStartAtion(IHarvestResourceAction action)
        {
            this.startActions.Add(action);
        }

        public void RegisterStopActions(params IHarvestResourceAction[] actions)
        {
            this.stopActions.AddRange(actions);
        }

        public void RegisterStopAction(IHarvestResourceAction action)
        {
            this.stopActions.Add(action);
        }

        void IGameInitElement.InitGame()
        {
            this.heroComponent = this.heroService.GetHero().Get<IComponent_HarvestResource>();
        }

        void IGameReadyElement.ReadyGame()
        {
            this.heroComponent.OnHarvestStarted += this.OnHarvestStarted;
            this.heroComponent.OnHarvestStopped += this.OnHarvestStopped;
        }

        void IGameFinishElement.FinishGame()
        {
            this.heroComponent.OnHarvestStarted -= this.OnHarvestStarted;
            this.heroComponent.OnHarvestStopped -= this.OnHarvestStopped;
        }

        private void OnHarvestStarted(HarvestResourceOperation operation)
        {
            for (int i = 0, count = this.startActions.Count; i < count; i++)
            {
                var action = this.startActions[i];
                action.Do(operation);
            }
        }

        private void OnHarvestStopped(HarvestResourceOperation operation)
        {
            for (int i = 0, count = this.stopActions.Count; i < count; i++)
            {
                var action = this.stopActions[i];
                action.Do(operation);
            }
        }
    }
}