using Elementary;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Dummies
{
    [AddComponentMenu("Gameplay/Dummies/Dummy Visual Module")]
    public sealed class VisualModule : MonoModule
    {
        [SerializeField]
        private Animator animator;

        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<CoreModule>();
            
            coreModule.takeDamageEngine.AddListener(new Action_Animator_Play
            {
                animator = this.animator,
                animationName = "Hit",
                layerIndex = -1,
                normalizedTime = 0
            });
            
            coreModule.destroyReceiver.AddListener(new Action_Animator_Play
            {
                animator = this.animator,
                animationName = "Destroy",
                layerIndex = -1,
                normalizedTime = 0
            });
        }
    }
}