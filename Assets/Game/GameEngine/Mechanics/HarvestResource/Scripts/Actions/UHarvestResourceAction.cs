using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public abstract class UHarvestResourceAction : MonoBehaviour, IHarvestResourceAction
    {
        public abstract void Do(HarvestResourceOperation operation);
    }
}