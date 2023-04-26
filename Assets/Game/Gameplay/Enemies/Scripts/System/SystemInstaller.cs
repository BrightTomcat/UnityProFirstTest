using Entities;
using Game.GameEngine.Mechanics;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy System Installer")]
    public sealed class SystemInstaller : MonoGameInstaller
    {
        [Space]
        [SerializeField]
        private UnityEntity unit;

        [SerializeField]
        private UnityEntity ai;

        [Header("Controllers")]
        [SerializeField]
        [GameComponent(GameComponentType.ELEMENT)]
        private GameElement_SwitchEnableComponents enableController = new();

        [SerializeField]
        [GameComponent(GameComponentType.ELEMENT)]
        private RespawnController respawnController = new();

        public override void ConstructGame(IGameContext context)
        {
            this.enableController.Construct(this.unit, this.ai);
            this.respawnController.Construct(this.unit, this.ai);
        }
    }
}