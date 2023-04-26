using MonoOptimization;

namespace Game.GameEngine.Mechanics
{
    public sealed class HitPointsBarAdapter :
        IAwakeComponent,
        IEnableComponent,
        IDisableComponent
    {
        private IHitPointsEngine hitPointsEngine;

        private HitPointsBar view;
        
        public void Construct(IHitPointsEngine hitPointsEngine, HitPointsBar view)
        {
            this.hitPointsEngine = hitPointsEngine;
            this.view = view;
        }

        void IAwakeComponent.Awake()
        {
            this.SetupBar();
        }

        void IEnableComponent.OnEnable()
        {
            this.hitPointsEngine.OnHitPointsChanged += this.OnHitPointsChanged;
        }

        void IDisableComponent.OnDisable()
        {
            this.hitPointsEngine.OnHitPointsChanged -= this.OnHitPointsChanged;
        }

        private void OnHitPointsChanged(int hitPoints)
        {
            this.UpdateBar(hitPoints);
        }

        private void SetupBar()
        {
            var hitPoints = this.hitPointsEngine.CurrentHitPoints;
            var maxHitPoints = this.hitPointsEngine.MaxHitPoints;

            var showBar = hitPoints > 0;
            this.view.SetVisible(showBar);
            this.view.SetHitPoints(hitPoints, maxHitPoints);
        }

        private void UpdateBar(int hitPoints)
        {
            var maxHitPoints = this.hitPointsEngine.MaxHitPoints;
            var showBar = hitPoints > 0;

            this.view.SetVisible(showBar);
            this.view.SetHitPoints(hitPoints, maxHitPoints);
        }
    }
}