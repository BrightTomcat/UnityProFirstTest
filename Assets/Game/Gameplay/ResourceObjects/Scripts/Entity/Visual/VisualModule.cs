using Elementary;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.ResourceObjects
{
    [AddComponentMenu("Gameplay/Resource Objects/Resource Visual Module")]
    public class VisualModule : MonoModule
    {
        [SerializeField]
        private GameObject rootGameObject;
    
        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<CoreModule>();
            coreModule.lifeModule.activeVariable.AddListener(rootGameObject.SetActiveByAction());
        }
    }
}