using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Melee Combat/Component «Melee Combat»")]
    public sealed class UComponent_MeleeCombat : MonoBehaviour, IComponent_MeleeCombat
    {
        public event Action<MeleeCombatOperation> OnCombatStarted
        {
            add { this.combatEngine.OnCombatStarted += value; }
            remove { this.combatEngine.OnCombatStarted -= value; }
        }

        public event Action<MeleeCombatOperation> OnCombatStopped
        {
            add { this.combatEngine.OnCombatStopped += value; }
            remove { this.combatEngine.OnCombatStopped -= value; }
        }

        public bool IsCombat
        {
            get { return this.combatEngine.IsCombat; }
        }

        [SerializeField]
        private UMeleeCombatEngine combatEngine;

        public bool CanStartCombat(MeleeCombatOperation operation)
        {
            return this.combatEngine.CanStartCombat(operation);
        }

        public void StartCombat(MeleeCombatOperation operation)
        {
            this.combatEngine.StartCombat(operation);
        }

        public void StopCombat()
        {
            this.combatEngine.StopCombat();
        }
    }
}