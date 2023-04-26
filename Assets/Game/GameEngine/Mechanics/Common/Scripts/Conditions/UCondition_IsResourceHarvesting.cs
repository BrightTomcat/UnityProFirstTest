using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Condition «Is Resource Harvesting»")]
    public sealed class UCondition_IsResourceHarvesting : MonoCondition
    {
        [SerializeField]
        public UHarvestResourceEngine engine;
        
        public override bool IsTrue()
        {
            return this.engine.IsHarvesting;
        }
    }
}