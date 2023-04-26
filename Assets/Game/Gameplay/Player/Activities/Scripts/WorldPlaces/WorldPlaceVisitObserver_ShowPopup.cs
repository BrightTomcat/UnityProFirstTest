using Game.GameEngine;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public class WorldPlaceVisitObserver_ShowPopup : WorldPlaceVisitObserver
    {
        public PopupName PopupName
        {
            get { return this.popupName; }
        }

        [SerializeField]
        private PopupName popupName;

        private PopupManager popupManager;

        public override void ConstructGame(IGameContext context)
        {
            base.ConstructGame(context);
            this.popupManager = context.GetService<PopupManager>();
        }

        public override void ReadyGame()
        {
            base.ReadyGame();
            this.popupManager.OnPopupHidden += this.OnPopupHidden;
        }

        public override void FinishGame()
        {
            base.FinishGame();
            this.popupManager.OnPopupHidden -= this.OnPopupHidden;
        }

        protected sealed override void OnStartVisit()
        {
            var popupArgs = this.ProvidePopupArgs();
            this.popupManager.ShowPopup(this.popupName, popupArgs);
        }

        private object ProvidePopupArgs()
        {
            return null;
        }

        protected sealed override void OnEndVisit()
        {
        }

        private void OnPopupHidden(PopupName name)
        {
            if (name == this.popupName)
            {
                this.placeObservable.EndVisit();
            }
        }
    }
}