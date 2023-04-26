using System.Collections.Generic;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    public sealed class EntitiesSystemInstaller : MonoGameInstaller
    {
        [GameComponent]
        [Space, ReadOnly, ShowInInspector]
        private EntitySpawner spawner = new();

        [GameComponent]
        [ReadOnly, ShowInInspector]
        private EntityDestroyer destroyer = new();

        [ReadOnly, ShowInInspector]
        private EntitiesService entitiesService = new();

        public override IEnumerable<object> GetServices()
        {
            yield return this.spawner;
            yield return this.destroyer;
            yield return this.entitiesService;
        }
    }
}