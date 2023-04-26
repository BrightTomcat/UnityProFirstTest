using Entities;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    public sealed class EntityDestroyer
    {
        private static readonly Vector3 OUTSCENE_POSITION = new(10000, 10000, 10000);

        private IGameContext gameContext;

        [GameInject]
        public void Construct(IGameContext gameContext)
        {
            this.gameContext = gameContext;
        }

        public void Destroy(UnityEntity entity)
        {
            if (entity.TryGetComponent(out IGameElement gameElement))
            {
                this.gameContext.UnregisterElement(gameElement);
            }

            entity.transform.position = OUTSCENE_POSITION;
            GameObject.Destroy(entity.gameObject, 0.1f);
        }
    }
}