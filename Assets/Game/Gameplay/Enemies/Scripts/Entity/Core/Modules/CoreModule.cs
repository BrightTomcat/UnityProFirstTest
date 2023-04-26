using Elementary;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy Core Module")]
    public sealed class CoreModule : MonoModuleAuto
    {
        [SerializeField]
        public TransformEngine transformEngine = new();
        
        [SerializeField]
        public BoolVariable enableVariable = new();
        
        [Resolve]
        [SerializeField]
        public MoveModule moveModule;
        
        [Resolve]
        [SerializeField, FormerlySerializedAs("meleeCombatSystem")]
        public MeleeCombatModule meleeCombatModule = new();

        [Resolve]
        [SerializeField, FormerlySerializedAs("lifeSystem")]
        public LifeModule lifeModule = new();
    }
}