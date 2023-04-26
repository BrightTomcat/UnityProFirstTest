using System;
using Elementary;
using Game.GameEngine.Animation;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class AnimatorSystem : _AnimatorSystem<AnimatorStateType>
    {
        private IStateMachine<StateType> stateMachine;

        public void Construct(IStateMachine<StateType> stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public override void OnEnable()
        {
            base.OnEnable();
            this.stateMachine.OnStateSwitched += this.OnStateChanged;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            this.stateMachine.OnStateSwitched -= this.OnStateChanged;
        }
        
        private void OnStateChanged(StateType state)
        {
            if (state == StateType.IDLE)
            {
                this.ChangeState(AnimatorStateType.IDLE);
            }
            else if (state == StateType.MOVE)
            {
                this.ChangeState(AnimatorStateType.MOVE);
            }
            else if (state == StateType.MELEE_COMBAT)
            {
                this.ChangeState(AnimatorStateType.MELEE_COMBAT);
            }
            else if (state == StateType.DEATH)
            {
                this.ChangeState(AnimatorStateType.DEATH);
            }
        }
    }
}