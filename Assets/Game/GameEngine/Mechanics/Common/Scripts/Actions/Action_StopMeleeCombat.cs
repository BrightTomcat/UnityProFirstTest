using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Action_StopMeleeCombat : IAction
    {
        public IMeleeCombatEngine engine;

        public Action_StopMeleeCombat(IMeleeCombatEngine engine)
        {
            this.engine = engine;
        }

        public Action_StopMeleeCombat()
        {
        }

        public void Do()
        {
            if (this.engine.IsCombat)
            {
                this.engine.StopCombat();
            }
        }
    }
}