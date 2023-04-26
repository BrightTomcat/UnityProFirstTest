using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class EventMechanics_PlayAnimation : EventMechanics
    {
        [Space, SerializeField]
        public Animator animator;

        [SerializeField]
        public string animationName = "hit";

        protected override void OnEvent()
        {
            this.animator.Play(this.animationName, -1, 0);
        }
    }
}