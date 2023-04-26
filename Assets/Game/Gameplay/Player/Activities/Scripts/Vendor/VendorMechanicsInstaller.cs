using GameSystem;
using UnityEngine;
using static GameSystem.GameComponentType;

namespace Game.Gameplay.Player
{
    public sealed class VendorMechanicsInstaller : MonoGameInstaller
    {
        [GameComponent(SERVICE)]
        [SerializeField]
        private VendorInteractor vendorInteractor = new();
    }
}