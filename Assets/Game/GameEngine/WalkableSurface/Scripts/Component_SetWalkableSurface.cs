using UnityEngine;

namespace Game.GameEngine
{
    public sealed class Component_SetWalkableSurface : MonoBehaviour
    {
        [SerializeField]
        private WalkableSurfaceHolder surfaceHolder;
    
        public void SetSurface(IWalkableSurface surface)
        {
            this.surfaceHolder.SetupSurface(surface);
        }
    }
}