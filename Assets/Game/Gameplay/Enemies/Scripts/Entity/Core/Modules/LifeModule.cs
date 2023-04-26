using System;
using Elementary;
using Game.GameEngine.Mechanics;
using MonoOptimization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [Serializable]
    public sealed class LifeModule
    {
        [Space]
        [SerializeField]
        public TakeDamageEngine takeDamageEngine = new();

        [Space]
        [SerializeField]
        public HitPointsEngine hitPointsEngine = new();

        [Space]
        [SerializeField]
        public BoolVariable isAlive = new();

        [Space]
        [SerializeField]
        public Emitter<DestroyArgs> destroyEmitter = new();

        [ShowInInspector]
        public Emitter respawnEvent = new();

        [Resolve]
        private void ConstructTakeDamage()
        {
            this.takeDamageEngine.Construct(this.hitPointsEngine, this.destroyEmitter);
        }

        [Resolve]
        private void ConstructDeath(MeleeCombatModule meleeCombatModule, MoveModule moveModule)
        {
            this.destroyEmitter.AddListener(new Action_StopMeleeCombat(meleeCombatModule.engine));
            this.destroyEmitter.AddListener(new Action_InterruptMoveInDirection(moveModule.engine));
            this.destroyEmitter.AddListener(this.isAlive.SetFalseByAction());
        }

        [Resolve]
        private void ConstructRespawn(MeleeCombatModule meleeCombatModule)
        {
            this.respawnEvent.AddListener(new Action_RestoreHitPoints(this.hitPointsEngine));
            this.respawnEvent.AddListener(this.isAlive.SetTrueByAction());
        }

        [Resolve]
        private void InitHitPoints(ConfigModule configModule)
        {
            var hitPoints = configModule.enemyConfig.hitPoints;
            this.hitPointsEngine.Setup(hitPoints, hitPoints);
        }
    }
}