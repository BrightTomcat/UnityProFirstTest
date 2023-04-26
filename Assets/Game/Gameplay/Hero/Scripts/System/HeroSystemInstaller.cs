using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using static GameSystem.GameComponentType;

namespace Game.Gameplay.Hero
{
    public sealed class HeroSystemInstaller : MonoGameInstaller
    {
        [Title("Services")]
        [GameComponent(SERVICE)]
        [ReadOnly, ShowInInspector]
        private HeroService heroService = new();

        [GameComponent(SERVICE)]
        [ReadOnly, ShowInInspector]
        private HeroWalkableSurface walkableSurface = new();

        [Title("Detectors")]
        [GameComponent(ELEMENT)]
        [ReadOnly, ShowInInspector]
        private EntityDetector entityDetector = new();

        [GameComponent]
        [SerializeField]
        private EnemyDetectObserver enemyDetectController = new();

        [GameComponent]
        [SerializeField]
        private ResourceDetectObserver resourceDetectController = new();

        [Title("Controllers")]
        [GameComponent(ELEMENT)]
        [ReadOnly, ShowInInspector]
        private HeroMoveController moveController = new();

        [GameComponent(ELEMENT)]
        [ReadOnly, ShowInInspector]
        private HeroDeathObserver deathController = new();

        [GameComponent(ELEMENT)]
        [ReadOnly, ShowInInspector]
        private HeroEnableController enableController = new();

        [Title("Collisions")]
        [GameComponent(ELEMENT)]
        [ReadOnly, ShowInInspector]
        private ConveyorVisitObserver conveyorVisitController = new();

        [GameComponent(ELEMENT)]
        [SerializeField]
        private VendorVisitController vendorVisitController = new();

        [GameComponent(ELEMENT)]
        [SerializeField]
        private WorldPlaceVisitController worldPlaceVisitController = new();

        [Title("Interactors")]
        [GameComponent(SERVICE | ELEMENT)]
        [SerializeField]
        private RespawnInteractor respawnInteractor;

        [GameComponent(ELEMENT)]
        [SerializeField]
        private MeleeCombatInteractor meleeCombatInteractor;

        [GameComponent(ELEMENT)]
        [SerializeField]
        private HarvestResourceInteractor harvestResourceInteractor;

        public override void ConstructGame(IGameContext context)
        {
            base.ConstructGame(context);
            this.ConstructDetector();
        }

        private void ConstructDetector()
        {
            this.entityDetector.AddListener(this.enemyDetectController);
            this.entityDetector.AddListener(this.resourceDetectController);
        }
    }
}