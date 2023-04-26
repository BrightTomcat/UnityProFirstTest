using Elementary;
using MonoOptimization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy Config Module")]
    public sealed class ConfigModule : MonoModule
    {
        [SerializeField]
        public ScriptableEnemy enemyConfig;
        
        [Space]
        [SerializeField, FormerlySerializedAs("minDistance")]
        public ScriptableFloat minMeleeDistance;
    }
}