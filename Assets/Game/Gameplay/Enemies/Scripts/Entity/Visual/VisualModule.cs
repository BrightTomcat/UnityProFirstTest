using Game.GameEngine.Animation;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy Visual Module")]
    public sealed class VisualModule : MonoModule
    {
        [SerializeField]
        public Animator animator;

        [SerializeField]
        public AnimatorDispatcher animatorDispatcher;
    }
}