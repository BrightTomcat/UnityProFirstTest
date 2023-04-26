using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Dummies
{
    [AddComponentMenu("Gameplay/Dummies/Dummy Config Module")]
    public sealed class ConfigModule : MonoModule
    {
        [SerializeField]
        public ScriptableDummy dummyConfig;
    }
}