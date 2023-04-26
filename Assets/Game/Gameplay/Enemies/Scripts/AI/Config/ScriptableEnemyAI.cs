using System;
using Entities;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [CreateAssetMenu(
        fileName = "ScriptableEnemyAI",
        menuName = "Gameplay/Enemies/New ScriptableEnemyAI"
    )]
    public sealed class ScriptableEnemyAI : ScriptableObject 
    {

        [Space]
        [SerializeField]
        public Stats stats;

        [Space]
        [SerializeField]
        public BlackboardKeys blackboardKeys;
        
        [Space]
        [SerializeField]
        public ScriptableEntityCondition[] detectOpponentConditions;
        
        [Serializable]
        public sealed class BlackboardKeys
        {
            [SerializeField]
            public string unitKey;

            [SerializeField]
            public string targetKey;

            [SerializeField]
            public string surfaceKey;

            [SerializeField]
            public string patrolIteratorKey;

            [SerializeField]
            public string movePositionKey;
        }

        [Serializable]
        public sealed class Stats
        {
            [SerializeField]
            public float meleeStoppingDistance;

            [SerializeField]
            public float pointStoppingDistance;

            [SerializeField]
            public float patrolWaitTime;
        }
    }
}