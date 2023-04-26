using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Condition «Is Not Melee Combat»")]
    public sealed class UCondition_IsNotMeleeCombat : MonoCondition
    {
        [SerializeField]
        public UMeleeCombatEngine engine;
        
        public override bool IsTrue()
        {
            return !this.engine.IsCombat;
        }
    }
}