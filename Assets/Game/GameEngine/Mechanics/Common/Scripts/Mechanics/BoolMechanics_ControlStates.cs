using System.Collections.Generic;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class BoolMechanics_ControlStates : BoolMechanics
    {
        public readonly List<IState> states = new();
        
        protected override void SetValue(bool isEnable)
        {
            if (isEnable)
            {
                this.EnterStates();
            }
            else
            {
                this.ExitStates();
            }
        }

        private void EnterStates()
        {
            for (int i = 0, count = this.states.Count; i < count; i++)
            {
                var state = this.states[i];
                state.Enter();
            }
        }

        private void ExitStates()
        {
            for (int i = 0, count = this.states.Count; i < count; i++)
            {
                var state = this.states[i];
                state.Exit();
            }
        }
    }
}