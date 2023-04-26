using System;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class EventMechanics_RestoreHitPoints : EventMechanics
    {
        public IHitPointsEngine hitPointsEngine;

        protected override void OnEvent()
        {
            this.hitPointsEngine.AssignToMax();
        }
    }
}