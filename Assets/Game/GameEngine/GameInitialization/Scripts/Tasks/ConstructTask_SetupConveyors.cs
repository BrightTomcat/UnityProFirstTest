using Entities;
using Game.GameEngine.Entities;
using Game.Gameplay.Conveyors;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine
{
    [CreateAssetMenu(
        fileName = "Task «Setup Conveyors»",
        menuName = "GameEngine/Construct/New Task «Setup Conveyors»"
    )]
    public sealed class ConstructTask_SetupConveyors : ConstructTask
    {
        [SerializeField]
        private ScriptableEntityCondition conveyorCondition;

        public override void Construct(IGameContext gameContext)
        {
            if (gameContext.TryGetService(out ConveyorsService conveyorsService))
            {
                var entitiesService = gameContext.GetService<EntitiesService>();
                var conveyours = entitiesService.FindEntities(this.conveyorCondition);
                conveyorsService.SetupConveyours(conveyours);
            }
        }
    }
}