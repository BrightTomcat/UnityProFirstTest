using GameSystem;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class ResumeGameBehaviour : MonoBehaviour, IGameAttachElement
    {
        private IGameContext gameContext;

        public void ResumeGame()
        {
            if (this.gameContext.State == GameState.PAUSE)
            {
                this.gameContext.ResumeGame();
            }
        }

        void IGameAttachElement.AttachGame(IGameContext context)
        {
            this.gameContext = context;
        }
    }
}