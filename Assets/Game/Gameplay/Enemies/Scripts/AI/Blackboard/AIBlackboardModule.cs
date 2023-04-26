using AI.Blackboards;
using Game.GameEngine.AI;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy AI Blackboard Module")]
    public sealed class AIBlackboardModule : MonoModuleAuto
    {
        [SerializeField]
        public Blackboard blackboard = new ();
    }
}