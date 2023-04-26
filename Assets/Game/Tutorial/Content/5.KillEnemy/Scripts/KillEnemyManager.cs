using System;
using System.Collections;
using Entities;
using GameSystem;
using UnityEngine;

namespace Game.Tutorial
{
    [Serializable]
    public sealed class KillEnemyManager
    {
        private IGameContext gameContext;
        
        [SerializeField]
        private UnityEntity enemyPrefab;
        
        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private Transform spawnPoint;
        
        [SerializeField]
        private float destroyDelay = 1.25f;

        public void Construct(IGameContext context)
        {
            this.gameContext = context;
        }

        public UnityEntity SpawnEnemy()
        {
            var enemy = GameObject.Instantiate(
                this.enemyPrefab,
                this.spawnPoint.position,
                this.spawnPoint.rotation,
                this.worldTransform
            );

            var gameElement = enemy.GetComponent<IGameElement>();
            this.gameContext.RegisterElement(gameElement);

            return enemy;
        }

        public IEnumerator DestroyEnemy(UnityEntity entity)
        {
            var gameElement = entity.GetComponent<IGameElement>();
            this.gameContext.UnregisterElement(gameElement);
            
            yield return new WaitForSecondsRealtime(this.destroyDelay);
            GameObject.Destroy(entity.gameObject);
        }
    }
}