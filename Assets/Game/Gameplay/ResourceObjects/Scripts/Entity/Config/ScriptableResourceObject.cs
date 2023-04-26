using Game.GameEngine.GameResources;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Gameplay.ResourceObjects
{
    [CreateAssetMenu(
        fileName = "ScriptableResourceObject",
        menuName = "Gameplay/Resources/New ScriptableResourceObject"
    )]
    public sealed class ScriptableResourceObject : ScriptableObject
    {
        [FormerlySerializedAs("type")]
        [SerializeField]
        public ResourceType resourceType;

        [FormerlySerializedAs("count")]
        [SerializeField]
        public int resourceAmount;

        [Space]
        [SerializeField]
        public float respawnTime = 4.0f;
    }
}