using Entities;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    public sealed class EntitySpawner
    {
        private IGameContext gameContext;

        [GameInject]
        public void Construct(IGameContext context)
        {
            this.gameContext = context;
        }

        public UnityEntity Spawn(UnityEntity prefab, Transform parent, Vector3 position, Quaternion rotation)
        {
            var entity = GameObject.Instantiate(prefab, position, rotation, parent);
            if (entity.TryGetComponent(out IGameElement gameElement))
            {
                this.gameContext.RegisterElement(gameElement);
            }

            return entity;
        }
    }
}