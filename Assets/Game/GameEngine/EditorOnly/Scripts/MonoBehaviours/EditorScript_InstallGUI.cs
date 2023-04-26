#if UNITY_EDITOR
using Game.GameEngine.GUI;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine.Development
{
    public sealed class EditorScript_InstallGUI : MonoBehaviour
    {
        public void LoadInteface()
        {
            var gameSystem = FindObjectOfType<MonoGameContext>();
            GUIInstaller.InstallGUI(gameSystem);
        }
    }
}
#endif