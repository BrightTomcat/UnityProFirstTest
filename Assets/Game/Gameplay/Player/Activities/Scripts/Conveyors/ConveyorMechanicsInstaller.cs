using GameSystem;
using Sirenix.OdinInspector;
using static GameSystem.GameComponentType;

namespace Game.Gameplay.Player
{
    public sealed class ConveyorMechanicsInstaller : MonoGameInstaller
    {
        [GameComponent(SERVICE)]
        [ReadOnly, ShowInInspector]
        private ConveyorVisitor visitor = new();

        [GameComponent(ELEMENT)]
        [ReadOnly, ShowInInspector]
        private ConveyorVisitObserver_AddResourcesToPlayer addResourcesObserver = new();

        [GameComponent(ELEMENT)]
        [ReadOnly, ShowInInspector]
        private ConveyorVisitObserver_ExtractPlayerResources extractResourcesObserver = new();
    }
}