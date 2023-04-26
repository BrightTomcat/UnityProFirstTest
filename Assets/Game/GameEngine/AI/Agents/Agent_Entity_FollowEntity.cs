using System;
using AI.Agents;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.GameEngine.AI
{
    public class Agent_Entity_FollowEntity : Agent_Coroutine
    {
        public event Action<bool> OnTargetReached
        {
            add { this.moveAgent.OnTargetReached += value; }
            remove { this.moveAgent.OnTargetReached -= value; }
        }

        public bool IsTargetReached
        {
            get { return this.moveAgent.IsTargetReached; }
        }

        private readonly Agent_Entity_MoveToPosition moveAgent;

        private IComponent_GetPosition targetComponent;

        public Agent_Entity_FollowEntity(MonoBehaviour coroutineDispatcher) : base(coroutineDispatcher)
        {
            this.moveAgent = new Agent_Entity_MoveToPosition(coroutineDispatcher);
        }

        public void SetStoppingDistance(float stoppingDistance)
        {
            this.moveAgent.SetStoppingDistance(stoppingDistance);
        }

        public void SetFollowingEntity(IEntity followingEntity)
        {
            this.moveAgent.SetMovingEntity(followingEntity);
        }

        public void SetTargetEntity(IEntity targetEntity)
        {
            this.targetComponent = targetEntity.Get<IComponent_GetPosition>();

            var targetPosition = this.targetComponent.Position;
            this.moveAgent.SetTarget(targetPosition);
        }

        protected override void OnStart()
        {
            base.OnStart();
            this.moveAgent.Play();
        }

        protected override void OnStop()
        {
            base.OnStop();
            this.moveAgent.Stop();
        }

        protected override void Update()
        {
            var targetPosition = this.targetComponent.Position;
            this.moveAgent.SetTarget(targetPosition);
        }
    }
}