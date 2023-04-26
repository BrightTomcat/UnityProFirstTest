using System;
using System.Collections.Generic;
using Elementary;
using GameSystem;
using InputModule;
using Sirenix.OdinInspector;
using UnityEngine;
using static GameSystem.GameComponentType;

namespace Game.Gameplay.Player
{
    public sealed class InputSystemInstaller : MonoGameInstaller
    {
        [GameComponent(ELEMENT | SERVICE)]
        [ShowInInspector]
        private InputStateManager stateManager = new();

        [GameComponent(SERVICE)]
        [SerializeField]
        private JoystickInput joystick;

        private void Awake()
        {
            this.joystick.enabled = false;
        }

        public override void ConstructGame(IGameContext context)
        {
            this.ConstructStateManager();
        }

        private void ConstructStateManager()
        {
            var states = new List<InputStateManager.StateHolder>
            {
                new()
                {
                    key = InputStateType.BASE,
                    state = new StateComposite(
                        new InputState_Joystick(this.joystick)
                    )
                },
                new()
                {
                    key = InputStateType.LOCK,
                    state = new State()
                },
                new()
                {
                    key = InputStateType.DIALOG,
                    state = new State()
                }
            };

            this.stateManager.Setup(states);
        }
    }
}