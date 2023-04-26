using System;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using UnityEngine;
using UnityEngine.Serialization;
using static Game.GameEngine.Mechanics.MoveInDirectionEngine.UpdateMode;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class MoveModule
    {
        [MonoComponent]
        [SerializeField, FormerlySerializedAs("moveEngine")]
        public MoveInDirectionEngine engine = new(FIXED_UPDATE);

        [Resolve]
        private void Construct(CoreModule coreModule)
        {
            coreModule.enableVariable.AddListener(new BoolAction_EnableMoveInDirection(this.engine));
        }

        [Resolve]
        private void Init(CoreModule coreModule)
        {
            this.engine.IsEnabled = coreModule.enableVariable.Current;
        }
    }
}