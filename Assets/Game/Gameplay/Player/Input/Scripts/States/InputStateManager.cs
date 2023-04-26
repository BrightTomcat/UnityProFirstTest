using System;
using Elementary;
using GameSystem;

namespace Game.Gameplay.Player
{
    [Serializable]
    public sealed class InputStateManager : StateMachine<InputStateType>,
        IGameStartElement,
        IGameFinishElement
    {
        void IGameStartElement.StartGame()
        {
            this.Enter();
        }
        
        void IGameFinishElement.FinishGame()
        {
            this.Exit();
        }
    }
}