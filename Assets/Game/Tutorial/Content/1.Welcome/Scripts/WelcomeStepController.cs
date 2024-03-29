using Game.Tutorial.App;
using Game.Tutorial.Gameplay;
using Game.Tutorial.UI;
using GameSystem;
using UnityEngine;

namespace Game.Tutorial
{
    [AddComponentMenu("Tutorial/Step «Welcome»")]
    public sealed class WelcomeStepController : TutorialStepController
    {
        [SerializeField]
        private WelcomeConfig config;
        
        [SerializeField]
        private WelcomePopupShower popupShower;

        public override void ConstructGame(IGameContext context)
        {
            base.ConstructGame(context);
            
            var frameManager = context.GetService<PopupManager>();
            this.popupShower.Construct(frameManager, this.config);
        }
        
        protected override void OnStart()
        {
            TutorialAnalytics.LogEventAndCache("tutorial_step_1__welcome_started");
            this.StartCoroutine(this.popupShower.ShowPopup(this.OnPopupClicked));
        }

        private void OnPopupClicked()
        {
            TutorialAnalytics.LogEventAndCache("tutorial_step_1__welcome_completed");
            this.NotifyAboutCompleteAndMoveNext();
        }
    }
}