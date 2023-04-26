using System;
using Elementary;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class IdleStateModule
    {
        public IState GetState()
        {
            return new State();
        }
    }
}