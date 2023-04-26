using System;
using System.Collections.Generic;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Animation
{
    [Serializable]
    public abstract class AnimatorStateEvent : State
    {
        [SerializeField]
        public AnimatorSystem animationSystem;

        [SerializeField, Space]
        public List<string> animationEvents = new()
        {
            "harvest"
        };

        public override void Enter()
        {
            this.animationSystem.OnStringReceived += this.OnAnimationEvent;
        }

        public override void Exit()
        {
            this.animationSystem.OnStringReceived -= this.OnAnimationEvent;
        }

        private void OnAnimationEvent(string message)
        {
            if (this.animationEvents.Contains(message))
            {
                this.OnEvent();
            }
        }

        protected abstract void OnEvent();
    }
}