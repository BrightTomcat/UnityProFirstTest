using Game.Gameplay.Hero;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class HarvestResourceMechanicsInstaller : MonoGameInstaller
    {
        [SerializeField]
        private AudioClip collectSFX;

        [GameComponent(GameComponentType.ELEMENT)]
        [ShowInInspector, ReadOnly]
        private HarvestResourceObserver harvestObserver = new();

        public override void ConstructGame(IGameContext context)
        {
            var heroService = context.GetService<HeroService>();
            this.harvestObserver.Construct(heroService);
            
            var resourceStorage = context.GetService<ResourceStorage>();
            var uiAnimator = context.GetService<ResourcePanelAnimator_AddJumpedResources>();

            this.harvestObserver.RegisterStopActions(
                new HarvestResourceAction_AddResourcesToStorage(resourceStorage),
                new HarvestResourceAction_AddResourcesToInterface(uiAnimator),
                new HarvestResourceAction_PlaySound(this.collectSFX)
            );
        }
    }
}