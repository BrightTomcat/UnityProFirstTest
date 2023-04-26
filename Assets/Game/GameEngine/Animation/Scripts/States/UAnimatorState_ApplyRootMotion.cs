using Elementary;
using UnityEngine;

namespace Game.GameEngine.Animation
{
    [AddComponentMenu("GameEngine/Animation/Animator State «Apply Root Motion»")]
    public sealed class UAnimatorState_ApplyRootMotion : MonoState
    {
        [SerializeField]
        private UAnimatorSystem system;

        public override void Enter()
        {
            this.system.ApplyRootMotion();
        }
    }
}