using Elementary;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Dummies
{
    [AddComponentMenu("Gameplay/Dummies/Dummy Collision Module")]
    public sealed class CollisionModule : MonoModule
    {
        [SerializeField]
        private GameObject root;

        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<CoreModule>();
            coreModule.destroyReceiver.AddListener(this.root.SetActiveFalseByAction());
        }
    }
}