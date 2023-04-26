using UnityEngine;

namespace Game.GameEngine
{
    public sealed class WorldPlaceTrigger : MonoBehaviour
    {
        public WorldPlaceType PlaceType
        {
            get { return this.placeType; }
        }

        [SerializeField]
        private WorldPlaceType placeType;
    }
}