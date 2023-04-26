using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class BoolAction_State_EnterExit : IAction<bool>
    {
        public IState state;

        public BoolAction_State_EnterExit()
        {
        }

        public BoolAction_State_EnterExit(IState state)
        {
            this.state = state;
        }

        public void Do(bool isEnable)
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