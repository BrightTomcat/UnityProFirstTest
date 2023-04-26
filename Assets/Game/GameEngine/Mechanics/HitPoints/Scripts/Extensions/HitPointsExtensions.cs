namespace Game.GameEngine.Mechanics
{
    public static class HitPointsExtensions
    {
        public static void AssignToMax(this IHitPointsEngine engine)
        {
            engine.CurrentHitPoints = engine.MaxHitPoints;
        }
    }
}