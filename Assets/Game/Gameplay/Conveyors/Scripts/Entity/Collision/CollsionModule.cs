using Game.Gameplay.Conveyors;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay
{
    [AddComponentMenu("Gameplay/Conveyors/Conveyor Collision Module")]
    public sealed class CollsionModule : MonoModule
    {
        [SerializeField]
        private ConveyorTrigger[] triggers;

        public override void Construct(MonoContextModular context)
        {
            var entity = context.GetModule<ComponentsModule>().entity;
            for (int i = 0, count = this.triggers.Length; i < count; i++)
            {
                var trigger = this.triggers[i];
                trigger.Setup(entity);
            }
        }
    }
}