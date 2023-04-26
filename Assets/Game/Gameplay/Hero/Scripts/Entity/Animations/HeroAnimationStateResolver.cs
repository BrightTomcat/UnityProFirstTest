using Elementary;
using Game.GameEngine.Animation;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    public sealed class HeroAnimationStateResolver : MonoBehaviour
    {
        [SerializeField]
        private UAnimatorSystem animationSystem;

        [SerializeField]
        private ScriptableInt idleStateId;

        [SerializeField]
        private ScriptableInt moveStateId;

        [SerializeField]
        private ScriptableInt chopStateId;

        [SerializeField]
        private ScriptableInt attackStateId;

        [SerializeField]
        private ScriptableInt mineStateId;

        [SerializeField]
        private ScriptableInt dieStateId;

        [Title("References")]
        [SerializeField]
        private HeroStateMachine stateMachine;

        [SerializeField]
        private UHarvestResourceEngine harvestEngine;

        private void OnEnable()
        {
            this.stateMachine.OnStateSwitched += this.OnStateChanged;
        }

        private void OnDisable()
        {
            this.stateMachine.OnStateSwitched -= this.OnStateChanged;
        }

        private void OnStateChanged(HeroStateType state)
        {
            if (state == HeroStateType.IDLE)
            {
                this.animationSystem.ChangeState(this.idleStateId.Current);
            }
            else if (state == HeroStateType.MOVE)
            {
                this.animationSystem.ChangeState(this.moveStateId.Current);
            }
            else if (state == HeroStateType.HARVEST_RESOURCE)
            {
                this.animationSystem.ChangeState(this.SelectHarvestAnimation());
            }
            else if (state == HeroStateType.MELEE_COMBAT)
            {
                this.animationSystem.ChangeState(this.attackStateId.Current);
            }
            else if (state == HeroStateType.DEATH)
            {
                this.animationSystem.ChangeState(this.dieStateId.Current);
            }
        }

        private int SelectHarvestAnimation()
        {
            var operation = this.harvestEngine.CurrentOperation;
            var resourceType = operation.resourceType;
            if (resourceType == ResourceType.WOOD)
            {
                return this.chopStateId.Current;
            }

            if (resourceType == ResourceType.STONE)
            {
                return this.mineStateId.Current;
            }

            //By default:
            return this.chopStateId.Current;
        }
    }
}