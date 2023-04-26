using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [CreateAssetMenu(
        fileName = "ScriptableEnemy",
        menuName = "Gameplay/Enemies/New ScriptableEnemy"
    )]
    public sealed class ScriptableEnemy : ScriptableObject
    {
        [SerializeField]
        public int hitPoints = 3;
        
        [SerializeField]
        public float moveSpeed = 5;

        [SerializeField]
        public int damage = 1;

        [Space]
        [SerializeField]
        public string enemyName = "Ork";
    }
}