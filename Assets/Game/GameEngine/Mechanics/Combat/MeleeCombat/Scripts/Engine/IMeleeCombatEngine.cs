using System;

namespace Game.GameEngine.Mechanics
{
    public interface IMeleeCombatEngine
    {
        event Action<MeleeCombatOperation> OnCombatStarted;

        event Action<MeleeCombatOperation> OnCombatStopped;

        bool IsCombat { get; }

        MeleeCombatOperation CurrentOperation { get;}

        bool CanStartCombat(MeleeCombatOperation operation);

        void StartCombat(MeleeCombatOperation operation);

        void StopCombat();
    }
}