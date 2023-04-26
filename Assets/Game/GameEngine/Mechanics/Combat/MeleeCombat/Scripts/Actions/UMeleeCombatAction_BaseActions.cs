using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Melee Combat/Melee Combat Action «Base Actions»")]
    public sealed class UMeleeCombatAction_BaseActions : UMeleeCombatAction
    {
        [SerializeField]
        public MonoAction[] actions;
    
        public override void Do(MeleeCombatOperation args)
        {
            for (int i = 0, count = this.actions.Length; i < count; i++)
            {
                var action = this.actions[i];
                action.Do();
            }
        }
    }
}