using System;
using Elementary;
using Game.GameEngine;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Player;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class WorldPlaceVisitController : VisitController<WorldPlaceTrigger>
    {
        [Space]
        [SerializeField]
        private float visitDelay = 0.2f;

        private WorldPlaceVisitor placeObservable;

        [GameInject]
        public void Construct(WorldPlaceVisitor placeObservable)
        {
            this.placeObservable = placeObservable;
        }

        protected override bool IsTargetEntered(WorldPlaceTrigger entity)
        {
            return true;
        }

        protected override ICondition ProvideVisitCondition(WorldPlaceTrigger target)
        {
            return new ConditionComposite(
                ConditionComposite.Mode.AND,
                new ConditionCountdown(this.monoContext, seconds: this.visitDelay, startInstantly: true),
                new Condition_Entity_IsNotMoving(this.HeroService.GetHero())
            );
        }

        protected override void OnHeroVisit(WorldPlaceTrigger target)
        {
            var placeType = target.PlaceType;
            if (this.placeObservable.IsVisiting && this.placeObservable.CurrentPlace != placeType)
            {
                this.placeObservable.EndVisit();
            }

            this.placeObservable.StartVisit(placeType);
        }

        protected override void OnHeroQuit(WorldPlaceTrigger target)
        {
            var placeType = target.PlaceType;
            if (this.placeObservable.IsVisiting && placeType == target.PlaceType)
            {
                this.placeObservable.EndVisit();
            }
        }
    }
}