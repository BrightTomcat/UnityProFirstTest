using Elementary;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.ResourceObjects
{
    [AddComponentMenu("Gameplay/Resource Objects/Resource Collision Module")]
    public sealed class CollisionModule : MonoModule
    {
        [SerializeField]
        private Collider[] colliders;

        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<CoreModule>();
            coreModule.lifeModule.activeVariable.AddListener(this.colliders.EnabledByAction());
        }
    }
}