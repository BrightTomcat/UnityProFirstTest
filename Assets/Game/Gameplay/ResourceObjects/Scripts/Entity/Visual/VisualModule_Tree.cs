using Elementary;
using MonoOptimization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.ResourceObjects
{
    [AddComponentMenu("Gameplay/Resource Objects/Resource Visual Module «Tree»")]
    public sealed class VisualModule_Tree : VisualModule
    {
        [Title("Tree")]
        [SerializeField]
        private Animator animator;

        public override void Construct(MonoContextModular context)
        {
            base.Construct(context);

            var core = context.GetModule<CoreModule>();
            core.takeHitEvent.AddListener(new Action_Animator_Play
            {
                animator = animator,
                animationName = "Chop",
                layerIndex = -1,
                normalizedTime = 0
            });
        }
    }
}