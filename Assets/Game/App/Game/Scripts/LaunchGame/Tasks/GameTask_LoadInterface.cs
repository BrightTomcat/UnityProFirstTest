using System;
using Game.GameEngine.GUI;
using GameSystem;
using UnityEngine;

namespace Game.App
{
    public sealed class GameTask_LoadInterface : ILoadingTask
    {
        public void Do(Action<LoadingResult> callback)
        {
            var gameSystem = GameObject.FindObjectOfType<MonoGameContext>();
            GUIInstaller.InstallGUI(gameSystem);
            callback?.Invoke(LoadingResult.Success());
        }
    }
}