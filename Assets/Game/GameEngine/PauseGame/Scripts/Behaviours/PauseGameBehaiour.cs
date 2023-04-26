using GameSystem;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class PauseGameBehaiour : MonoBehaviour, IGameAttachElement
    {
        private IGameContext gameContext;

        public void PauseGame()
        {
            if (this.gameContext.State == GameState.PLAY)
            {
                this.gameContext.PauseGame();
            }
        }

        void IGameAttachElement.AttachGame(IGameContext context)
        {
            this.gameContext = context;
        }
    }
}