using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.ResourceObjects
{
    [AddComponentMenu("Gameplay/Resource Objects/Resource Config Module")]
    public sealed class ConfigModule : MonoModule
    {
        [SerializeField]
        public ScriptableResourceObject info;
    }
}