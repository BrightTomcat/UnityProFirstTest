using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Condition «Is Melee Combat»")]
    public sealed class UCondition_IsMeleeCombat : MonoCondition
    {
        [SerializeField]
        public UMeleeCombatEngine engine;
        
        public override bool IsTrue()
        {
            return this.engine.IsCombat;
        }
    }
}