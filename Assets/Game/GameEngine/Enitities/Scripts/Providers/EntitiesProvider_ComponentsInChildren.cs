using System.Collections.Generic;
using Entities;

namespace Game.GameEngine.Entities
{
    public sealed class EntitiesProvider_ComponentsInChildren : EntitiesProvider
    {
        public override IEnumerable<IEntity> ProvideEntities()
        {
            return this.GetComponentsInChildren<IEntity>();
        }
    }
}