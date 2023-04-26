namespace Game.GameEngine.Mechanics
{
    public sealed class Component_IsDestroyed_HitPointsEngine : IComponent_IsDestroyed
    {
        public bool IsDestroyed
        {
            get { return this.hitPointsEngine.CurrentHitPoints <= 0; }
        }

        private readonly IHitPointsEngine hitPointsEngine;

        public Component_IsDestroyed_HitPointsEngine(IHitPointsEngine hitPointsEngine)
        {
            this.hitPointsEngine = hitPointsEngine;
        }
    }
}