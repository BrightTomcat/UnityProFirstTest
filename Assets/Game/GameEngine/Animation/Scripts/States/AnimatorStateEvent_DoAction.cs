using Elementary;

namespace Game.GameEngine.Animation
{
    public sealed class AnimatorStateEvent_DoAction : AnimatorStateEvent
    {
        public IAction Action
        {
            set { this.action = value; }
        }

        private IAction action;

        protected override void OnEvent()
        {
            this.action.Do();
        }
    }
}