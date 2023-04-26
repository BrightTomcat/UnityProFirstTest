using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Destroy/Component «Is Destroyed» (Hit Points Engine)")]
    public sealed class UComponent_IsDestroyed_HitPointsEngine : MonoBehaviour, IComponent_IsDestroyed
    {
        [PropertyOrder(-10)]
        [ReadOnly]
        [ShowInInspector]
        public bool IsDestroyed
        {
            get { return this.CheckIsDestroyed(); }
        }

        [Space]
        [SerializeField]
        private UHitPointsEngine hitPointsEngine;

        private bool CheckIsDestroyed()
        {
            if (this.hitPointsEngine == null)
            {
                return default;
            }

            return this.hitPointsEngine.CurrentHitPoints <= 0;
        }
    }
}