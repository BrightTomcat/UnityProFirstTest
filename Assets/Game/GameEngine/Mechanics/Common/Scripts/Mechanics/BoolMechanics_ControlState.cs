using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class BoolMechanics_ControlState : BoolMechanics
    {
        public IState state;

        protected override void SetValue(bool isEnable)
        {
            if (isEnable)
            {
                this.state.Enter();
            }
            else
            {
                this.state.Exit();
            }
        }
    }
}