using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Action «Stop Melee Combat»")]
    public sealed class UAction_StopMeleeCombat : MonoAction
    {
        [SerializeField]
        public UMeleeCombatEngine engine;

        public override void Do()
        {
            if (this.engine.IsCombat)
            {
                this.engine.StopCombat();
            }
        }
    }
}