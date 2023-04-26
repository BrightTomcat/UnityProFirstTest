using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Event Mechanics «Restore Hit Points»")]
    public sealed class UEventMechanics_RestoreHitPoints : MonoEventMechanics
    {
        [SerializeField]
        public UHitPointsEngine hitPointsEngine;

        protected override void OnEvent()
        {
            this.hitPointsEngine.CurrentHitPoints = this.hitPointsEngine.MaxHitPoints;
        }
    }
}