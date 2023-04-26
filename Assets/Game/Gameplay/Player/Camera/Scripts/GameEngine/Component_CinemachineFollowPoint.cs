using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class Component_CinemachineFollowPoint : MonoBehaviour
    {
        public Transform Point
        {
            get { return this.point; }
        }

        [SerializeField]
        private Transform point;
    }
}