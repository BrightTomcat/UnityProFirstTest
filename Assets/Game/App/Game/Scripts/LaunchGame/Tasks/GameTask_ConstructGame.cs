using System;
using Services;

namespace Game.App
{
    public class GameTask_ConstructGame : ILoadingTask
    {
        private readonly GameManager gameManager;

        [ServiceInject]
        public GameTask_ConstructGame(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }
    
        public void Do(Action<LoadingResult> callback)
        {
            this.gameManager.ConstructGame();
            callback?.Invoke(LoadingResult.Success());
        }
    }
}