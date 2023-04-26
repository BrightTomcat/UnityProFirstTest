using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy AI Config Module")]
    public sealed class AIConfigModule : MonoModule
    {
        [SerializeField]
        public ScriptableEnemyAI aiConfig;
    }
}