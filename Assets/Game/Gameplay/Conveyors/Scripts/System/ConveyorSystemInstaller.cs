using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Conveyors
{
    public sealed class ConveyorSystemInstaller : MonoGameInstaller
    {
        [GameComponent(GameComponentType.SERVICE)]
        [ReadOnly, ShowInInspector]
        private ConveyorsService conveyorsService = new();

        [GameComponent(GameComponentType.ELEMENT)]
        [Space, ReadOnly, ShowInInspector]
        private ConveyorsEnableController enableController = new();
    }
}