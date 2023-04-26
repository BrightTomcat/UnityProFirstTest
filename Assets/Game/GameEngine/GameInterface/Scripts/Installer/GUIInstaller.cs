using GameSystem;
using UnityEngine;

namespace Game.GameEngine.GUI
{
    public static class GUIInstaller
    {
        private const string PREFAB_NAME = "[GAME_INTERFACE]";

        public static void InstallGUI(MonoGameContext gameContext)
        {
            var guiPrefab = Resources.Load<GameObject>(PREFAB_NAME);
            var gameInteface = GameObject.Instantiate(guiPrefab);
            gameInteface.name = PREFAB_NAME;

            var gameElement = gameInteface.GetComponent<IGameElementGroup>();
            gameContext.RegisterElement(gameElement);
            
            var gameService = gameInteface.GetComponent<IGameServiceGroup>();
            gameContext.RegisterService(gameService);
        }
    }
}