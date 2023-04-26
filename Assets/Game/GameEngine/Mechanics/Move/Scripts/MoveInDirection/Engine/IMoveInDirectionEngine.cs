using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public interface IMoveInDirectionEngine
    {
        event Action OnStartMove;

        event Action OnStopMove;

        bool IsMoving { get; }

        bool IsEnabled { get; set; }

        Vector3 Direction { get; }

        bool CanMove(Vector3 direction);

        void Move(Vector3 direction);

        void InterruptMove();
    }
}