using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy AI Sensor Module")]
    public sealed class AISensorModule : MonoModuleAuto
    {
        [SerializeField]
        public CollidersSensorOverlapSphere sensor;

        public override void Construct(MonoContextModular context)
        {
            var blackboardModule = context.GetModule<AIBlackboardModule>();
            var blackboard = blackboardModule.blackboard;

            var configModule = context.GetModule<AIConfigModule>();
            var targetKey = configModule.aiConfig.blackboardKeys.targetKey;
            var detectConditions = configModule.aiConfig.detectOpponentConditions;
            
            var coreModule = context.GetModule<AICoreModule>();
            var isAIEnable = coreModule.enableVariable;

            this.sensor.AddListener(new SensorObserver_DetectOpponent(blackboard, targetKey, detectConditions));
            isAIEnable.AddListener(new BoolAction_PlayStopColliderSensor(this.sensor));
        }
    }
}