using System;
using UnityEngine;

namespace Game.Gameplay.Vendors
{
    [Serializable]
    public sealed class VendorVisual
    {
        public Animator Animator
        {
            set { this.animator = value; }
        }

        private Animator animator;
        
        [SerializeField]
        private string animationName = "Dance";

        public void NotifyAboutDealCompleted()
        {
            this.animator.Play(this.animationName, -1, 0);
        }
    }
}