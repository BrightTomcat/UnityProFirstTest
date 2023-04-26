using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class MoveInDirectionState_Rotation : StateUpdated
    {
        [Space]
        [SerializeField]
        private Mode mode = Mode.INSTANTLY;

        [ShowIf("mode", Mode.SMOOTH)]
        [SerializeField]
        private float rotationSpeed = 45;

        private IMoveInDirectionEngine moveEngine;

        private ITransformEngine transformEngine;

        public void Construct(IMoveInDirectionEngine moveEngine, ITransformEngine transformEngine)
        {
            this.moveEngine = moveEngine;
            this.transformEngine = transformEngine;
        }

        protected override void Update(float deltaTime)
        {
            if (this.moveEngine.IsMoving)
            {
                this.RotateInDirection(deltaTime);
            }
        }

        private void RotateInDirection(float deltaTime)
        {
            var direction = this.moveEngine.Direction;
            if (this.mode == Mode.INSTANTLY)
            {
                this.transformEngine.LookInDirection(direction);
            }
            else if (this.mode == Mode.SMOOTH)
            {
                this.transformEngine.RotateTowardsInDirection(direction, this.rotationSpeed, deltaTime);
            }
        }

        private enum Mode
        {
            INSTANTLY = 0,
            SMOOTH = 1
        }
    }
}