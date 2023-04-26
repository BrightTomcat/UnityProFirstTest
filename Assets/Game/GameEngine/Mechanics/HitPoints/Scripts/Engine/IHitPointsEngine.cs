using System;

namespace Game.GameEngine.Mechanics
{
    public interface IHitPointsEngine
    {
         event Action OnSetuped; 

        event Action<int> OnHitPointsChanged;

        event Action<int> OnMaxHitPointsChanged;

        event Action OnHitPointsFull;

        event Action OnHitPointsEmpty;

        int CurrentHitPoints { get; set; }

        int MaxHitPoints { get; set; }

        void Setup(int current, int max);

        
    }
}