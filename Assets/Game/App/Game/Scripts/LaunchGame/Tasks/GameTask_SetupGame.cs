using System;
using System.Threading.Tasks;
using GameSystem;
using Services;
using UnityEngine;

namespace Game.App
{
    public sealed class GameTask_SetupGame : ILoadingTask
    {
        private readonly GameManager gameManager;

        [ServiceInject]
        public GameTask_SetupGame(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }
    
        public void Do(Action<LoadingResult> callback)
        {
            var gameContext = GameObject.FindObjectOfType<MonoGameContext>();
            this.gameManager.SetupGame(gameContext);
            callback?.Invoke(LoadingResult.Success());
        }
    }
}