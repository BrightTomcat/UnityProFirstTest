using System;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_HitPoints :
        IComponent_GetHitPoints,
        IComponent_SetHitPoints,
        IComponent_GetMaxHitPoints,
        IComponent_SetMaxHitPoints,
        IComponent_AddHitPoints,
        IComponent_OnHitPointsChanged,
        IComponent_OnMaxHitPointsChanged,
        IComponent_SetupHitPoints
    {
        public event Action<int> OnHitPointsChanged
        {
            add { this.engine.OnHitPointsChanged += value; }
            remove { this.engine.OnHitPointsChanged -= value; }
        }

        public event Action<int> OnMaxHitPointsChanged
        {
            add { this.engine.OnMaxHitPointsChanged += value; }
            remove { this.engine.OnMaxHitPointsChanged -= value; }
        }

        public int HitPoints
        {
            get { return this.engine.CurrentHitPoints; }
        }

        public int MaxHitPoints
        {
            get { return this.engine.MaxHitPoints; }
        }

        private readonly IHitPointsEngine engine;

        public Component_HitPoints(IHitPointsEngine engine)
        {
            this.engine = engine;
        }

        public void Setup(int current, int max)
        {
            this.engine.Setup(current, max);
        }

        public void SetHitPoints(int hitPoints)
        {
            this.engine.CurrentHitPoints = hitPoints;
        }

        public void SetMaxHitPoints(int hitPoints)
        {
            this.engine.MaxHitPoints = hitPoints;
        }

        public void AddHitPoints(int range)
        {
            this.engine.CurrentHitPoints += range;
        }
    }
}