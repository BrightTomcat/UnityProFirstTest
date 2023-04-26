using System;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_RangeCombat
    {
        event Action<RangeCombatOperation> OnCombatStarted;

        event Action<RangeCombatOperation> OnCombatStopped;

        bool IsCombat { get; }

        bool CanStartCombat(RangeCombatOperation operation);
        
        void StartCombat(RangeCombatOperation operation);
        
        void StopCombat();
    }
}