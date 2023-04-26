using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public abstract class State_CheckDistanceToTarget : StateFixedUpdated
    {
        public ITransformEngine transformEngine;

        public IValue<float> minDistance;

        protected override void FixedUpdate(float deltaTime)
        {
            var targetPosiiton = this.GetTargetPosition();
            var distanceReached = this.transformEngine.IsDistanceReached(targetPosiiton, this.minDistance.Current);
            this.ProcessDistance(distanceReached);
        }

        protected abstract void ProcessDistance(bool distanceReached);
        
        protected abstract Vector3 GetTargetPosition();
    }
}