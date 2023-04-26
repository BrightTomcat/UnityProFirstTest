using Elementary;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy Collision Module")]
    public sealed class CollisionModule : MonoModule
    {
        [SerializeField]
        private GameObject rootGameObject;
        
        [SerializeField]
        private Collider[] colliders;
        
        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<CoreModule>();
            coreModule.enableVariable.AddListener(this.rootGameObject.SetActiveByAction());
            coreModule.lifeModule.isAlive.AddListener(this.colliders.EnabledByAction());
        }
    }
}