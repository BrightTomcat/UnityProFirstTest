using UnityEngine;

namespace Game.GameEngine
{
    public sealed class Component_GetWorldPlaceType : MonoBehaviour, IComponent_GetWorldPlaceType
    {
        public WorldPlaceType Type
        {
            get { return this.type; }
        }

        [SerializeField]
        private WorldPlaceType type;
    }
}