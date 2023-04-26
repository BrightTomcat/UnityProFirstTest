using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Action «Stop Harvest Resource»")]
    public sealed class UAction_StopHarvestResource : MonoAction
    {
        [SerializeField]
        public UHarvestResourceEngine engine;
    
        public override void Do()
        {
            if (this.engine.IsHarvesting)
            {
                this.engine.StopHarvest();
            }
        }
    }
}