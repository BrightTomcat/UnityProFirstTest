using System;
using Elementary;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class DieStateModule
    {
        public IState GetState()
        {
            return new State();
        }
    }
}