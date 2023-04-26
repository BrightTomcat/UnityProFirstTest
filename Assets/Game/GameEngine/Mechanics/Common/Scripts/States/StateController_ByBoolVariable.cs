using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class StateController_ByBoolVariable : BoolMechanics
    {
        public IState stateMachine;

        protected override void SetValue(bool isEnable)
        {
            if (isEnable)
            {
                this.stateMachine.Enter();
            }
            else
            {
                this.stateMachine.Exit();
            }
        }
    }
}