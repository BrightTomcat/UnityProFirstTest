using Game.GameEngine;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public abstract class WorldPlaceVisitObserver : MonoBehaviour,
        IGameConstructElement,
        IGameReadyElement,
        IGameFinishElement
    {
        protected WorldPlaceVisitor placeObservable;

        [SerializeField]
        private WorldPlaceType placeType;

        public virtual void ConstructGame(IGameContext context)
        {
            this.placeObservable = context.GetService<WorldPlaceVisitor>();
        }

        public virtual void ReadyGame()
        {
            this.placeObservable.OnVisitStarted += this.OnVisitStarted;
            this.placeObservable.OnVisitEnded += this.OnVisitEnded;
        }

        public virtual void FinishGame()
        {
            this.placeObservable.OnVisitStarted -= this.OnVisitStarted;
            this.placeObservable.OnVisitEnded -= this.OnVisitEnded;
        }

        private void OnVisitStarted(WorldPlaceType visitPlaceType)
        {
            if (visitPlaceType == this.placeType)
            {
                this.OnStartVisit();
            }
        }

        private void OnVisitEnded(WorldPlaceType visitPlaceType)
        {
            if (visitPlaceType == this.placeType)
            {
                this.OnEndVisit();
            }
        }

        protected virtual void OnStartVisit()
        {
        }

        protected virtual void OnEndVisit()
        {
        }
    }
}