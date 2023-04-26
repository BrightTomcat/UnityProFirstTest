using UnityEngine;

namespace AI.GOAP
{
    [AddComponentMenu("AI/GOAP/World State Injector")]
    public sealed class WorldStateInjector : MonoBehaviour
    {
        [SerializeField]
        private UnityWorldState worldState;

        private void Awake()
        {
            var injects = this.GetComponentsInChildren<IWorldStateInjective>();
            for (int i = 0, count = injects.Length; i < count; i++)
            {
                var injection = injects[i];
                injection.WorldState = this.worldState;
            }
        }
    }
}