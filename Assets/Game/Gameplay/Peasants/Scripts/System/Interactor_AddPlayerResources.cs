using Entities;
using Game.Gameplay.Player;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Peasants
{
    [AddComponentMenu("Gameplay/Peasants/Peasant Interactor «Add Player Resources»")]
    public sealed class Interactor_AddPlayerResources : MonoBehaviour, IGameConstructElement
    {
        private ResourceStorage resourceStorage;
        
        public void MoveResourcesFrom(IEntity peasant)
        {
            var bagComponent = peasant.Get<Component_Bag>();
            foreach (var resourceKV in bagComponent.GetAllResources())
            {
                var resourceType = resourceKV.type;
                var amount = resourceKV.amount;
                bagComponent.ExtractResources(resourceType, amount);
                this.resourceStorage.AddResource(resourceType, amount);
            }
        }

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            this.resourceStorage = context.GetService<ResourceStorage>();
        }
    }
}