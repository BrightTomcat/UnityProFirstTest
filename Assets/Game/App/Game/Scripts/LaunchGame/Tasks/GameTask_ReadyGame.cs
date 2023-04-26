using System;
using System.Threading.Tasks;
using Services;

namespace Game.App
{
    public sealed class GameTask_ReadyGame : ILoadingTask
    {
        private readonly GameManager gameManager;

        [ServiceInject]
        public GameTask_ReadyGame(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void Do(Action<LoadingResult> callback)
        {
            this.gameManager.ReadyGame();
            callback.Invoke(LoadingResult.Success());
        }
    }
}