using System.Collections.Generic;
using Entities;

namespace Game.Gameplay.Hero
{
    public interface IEntityDetectObserver
    {
        void OnEntitiesUpdated(List<IEntity> entities);
    }
}