using System.Linq;
using Game.Gameplay.Player;
using Game.Tutorial.Gameplay;
using Game.Tutorial.UI;
using GameSystem;
using UIFrames.Unity;
using UnityEngine;

namespace Game.Tutorial
{
    [AddComponentMenu("Tutorial/Step «Move To Upgrade»")]
    public sealed class MoveToUpgradeStepController : TutorialStepController, IGameInitElement
    {
        private IGameContext gameContext;

        private PointerManager pointerManager;

        private NavigationManager navigationManager;

        private ScreenTransform screenTransform;

        private PopupManager popupManager;

        private WorldPlaceVisitObserver_ShowPopup upgradePopupShower;

        private readonly MoveToUpgradeInspector actionInspector = new();

        [SerializeField]
        private UpgradeHeroConfig config;

        [SerializeField]
        private MoveToUpgradePanelShower actionPanel;

        [SerializeField]
        private Transform pointerTransform;

        [SerializeField]
        private UnityFrame popupPrefab;

        public override void ConstructGame(IGameContext context)
        {
            this.gameContext = context;

            this.pointerManager = context.GetService<PointerManager>();
            this.navigationManager = context.GetService<NavigationManager>();
            this.screenTransform = context.GetService<ScreenTransform>();
            this.popupManager = context.GetService<PopupManager>();
            this.upgradePopupShower = this.FindPopupShower(context);

            var worldPlaceVisitor = context.GetService<WorldPlaceVisitor>();
            this.actionInspector.Construct(worldPlaceVisitor, this.config);
            this.actionPanel.Construct(this.config);

            base.ConstructGame(context);
        }

        void IGameInitElement.InitGame()
        {
            if (!this.IsStepFinished() && this.upgradePopupShower != null)
            {
                //Убираем базовый триггер
                this.gameContext.UnregisterElement(this.upgradePopupShower);
            }
        }

        protected override void OnStart()
        {
            //Подписываемся на подход к месту:
            this.actionInspector.Inspect(this.OnPlaceVisited);

            //Показываем указатель:
            var targetPosition = this.pointerTransform.position;
            this.pointerManager.ShowPointer(targetPosition, this.pointerTransform.rotation);
            this.navigationManager.StartLookAt(targetPosition);

            //Показываем квест в UI:
            this.StartCoroutine(this.actionPanel.Show(this.screenTransform.Value));
        }

        private void OnPlaceVisited()
        {
            //Возвращаем базовый триггер:
            this.gameContext.RegisterElement(this.upgradePopupShower);

            //Убираем указатель
            this.pointerManager.HidePointer();
            this.navigationManager.Stop();

            //Убираем квест из UI:
            this.actionPanel.Hide();

            //Показываем попап:
            this.popupManager.Show(this.popupPrefab, args: null);
        }

        private WorldPlaceVisitObserver_ShowPopup FindPopupShower(IGameContext context)
        {
            return context
                .GetServices<WorldPlaceVisitObserver_ShowPopup>()
                .FirstOrDefault(it => it.PopupName == this.config.requiredPopupName);
        }
    }
}