using Elementary;
using MonoOptimization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy AI Core Module")]
    public sealed class AICoreModule : MonoModule
    {
        [ShowInInspector, ReadOnly]
        public BoolVariable enableVariable = new();
    }
}