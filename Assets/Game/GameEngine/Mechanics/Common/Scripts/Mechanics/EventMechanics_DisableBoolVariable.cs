using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class EventMechanics_DisableBoolVariable : EventMechanics
    {
        public IVariable<bool> boolVariable;

        protected override void OnEvent()
        {
            this.boolVariable.Current = false;
        }
    }
}