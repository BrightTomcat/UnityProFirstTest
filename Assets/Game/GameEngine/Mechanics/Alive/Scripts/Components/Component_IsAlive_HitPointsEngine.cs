namespace Game.GameEngine.Mechanics
{
    public sealed class Component_IsAlive_HitPointsEngine : IComponent_IsAlive
    {
        public bool IsAlive
        {
            get { return this.engine.CurrentHitPoints > 0; }
        }

        private readonly IHitPointsEngine engine;

        public Component_IsAlive_HitPointsEngine(IHitPointsEngine engine)
        {
            this.engine = engine;
        }
    }
}