using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class MoveInDirectionState_Position : StateFixedUpdated
    {
        private IMoveInDirectionEngine moveEngine;

        private ITransformEngine transformEngine;

        private IValue<float> moveSpeed;

        public void Construct(
            IMoveInDirectionEngine moveEngine,
            ITransformEngine transformEngine,
            IValue<float> speed
        )
        {
            this.moveEngine = moveEngine;
            this.transformEngine = transformEngine;
            this.moveSpeed = speed;
        }
        
        protected override void FixedUpdate(float deltaTime)
        {
            if (this.moveEngine.IsMoving)
            {
                this.MoveInDirection(deltaTime);
            }
        }

        private void MoveInDirection(float deltaTime)
        {
            var velocity = this.moveEngine.Direction * (this.moveSpeed.Current * deltaTime);
            this.transformEngine.MovePosition(velocity);
        }
    }
}