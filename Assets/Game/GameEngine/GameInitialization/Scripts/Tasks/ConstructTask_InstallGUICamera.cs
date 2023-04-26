using Game.GameEngine.GUI;
using GameSystem;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Game.GameEngine
{
    [CreateAssetMenu(
        fileName = "Task «Install GUICamera»",
        menuName = "GameEngine/Construct/New Task «Install GUICamera»"
    )]
    public sealed class ConstructTask_InstallGUICamera : ConstructTask
    {
        public override void Construct(IGameContext gameContext)
        {
            var worldCameraData = WorldCamera.Instance.GetUniversalAdditionalCameraData();
            var uiCamera = gameContext.GetService<GUICameraService>().Camera;
            worldCameraData.cameraStack.Add(uiCamera);
        }
    }
}