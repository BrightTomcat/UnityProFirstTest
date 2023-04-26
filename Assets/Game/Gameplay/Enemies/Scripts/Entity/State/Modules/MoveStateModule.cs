using System;
using Elementary;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class MoveStateModule
    {
        [MonoComponent]
        [SerializeField]
        private MoveInDirectionState_Position updatePositionState = new();

        [MonoComponent]
        [SerializeField]
        private MoveInDirectionState_Rotation updateRotationState = new();

        [Resolve]
        private void Construct(CoreModule coreModule, ConfigModule configModule)
        {
            var moveEngine = coreModule.moveModule.engine;
            var transformEngine = coreModule.transformEngine;
            var moveSpeed = configModule.enemyConfig.moveSpeed;

            this.updatePositionState.Construct(moveEngine, transformEngine, new Value<float>(moveSpeed));
            this.updateRotationState.Construct(moveEngine, transformEngine);
        }

        public IState GetState()
        {
            return new StateComposite(
                this.updatePositionState,
                this.updateRotationState
            );
        }
    }
}