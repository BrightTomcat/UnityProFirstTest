using Game.Gameplay.Hero;
using GameSystem;
using Polygons;
using UnityEngine;

namespace Game.GameEngine
{
    [CreateAssetMenu(
        fileName = "Task «Setup Hero Walkable Surface»",
        menuName = "GameEngine/Construct/New Task «Setup Hero Walkable Surface»"
    )]
    public sealed class ConstructTask_SetupHeroWalkableSurface : ConstructTask
    {
        public override void Construct(IGameContext gameContext)
        {
            var walkablePolygons = GameObject.FindGameObjectsWithTag("Surface");
            var walkableSurface = gameContext.GetService<HeroWalkableSurface>();

            for (int i = 0, count = walkablePolygons.Length; i < count; i++)
            {
                var polygon = walkablePolygons[i].GetComponent<MonoPolygon>();
                walkableSurface.RegisterPolygon(polygon);
            }
            
            var hero = gameContext.GetService<HeroService>().GetHero();
            hero.Get<Component_SetWalkableSurface>().SetSurface(walkableSurface);
        }
    }
}