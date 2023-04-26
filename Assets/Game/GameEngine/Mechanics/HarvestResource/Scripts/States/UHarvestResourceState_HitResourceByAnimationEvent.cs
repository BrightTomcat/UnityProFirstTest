using System.Collections.Generic;
using Elementary;
using Game.GameEngine.Animation;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Harvest Resource State «Hit Resource By Anim Event»")]
    public sealed class UHarvestResourceState_HitResourceByAnimationEvent : MonoState
    {
        [SerializeField]
        public UHarvestResourceEngine harvestEngine;

        [SerializeField]
        public UHarvestResourceAction_HitResource hitAction;

        [Space]
        [SerializeField]
        public UAnimatorSystem animationSystem;
        
        [Space]
        [SerializeField]
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
            if (this.animationEvents.Contains(message) && this.harvestEngine.IsHarvesting)
            {
                this.hitAction.Do(this.harvestEngine.CurrentOperation);
            }
        }
    }
}