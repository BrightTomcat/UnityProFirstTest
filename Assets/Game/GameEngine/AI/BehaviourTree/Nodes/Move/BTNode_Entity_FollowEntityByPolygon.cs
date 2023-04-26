using System;
using AI.Blackboards;
using AI.BTree;
using Entities;
using Polygons;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [Serializable]
    public sealed class BTNode_Entity_FollowEntityByPolygon : BehaviourNode
    {
        public string UnitKey
        {
            set => unitKey = value;
        }

        public string TargetKey
        {
            set => targetKey = value;
        }

        public string SurfaceKey
        {
            set => surfaceKey = value;
        }

        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        [BlackboardKey]
        [SerializeField]
        private string surfaceKey;
        
        private IBlackboard blackboard;

        private Agent_Entity_FollowEntityByPolygon followAgent;

        public void Construct(
            MonoBehaviour monoContext,
            IBlackboard blackboard,
            float stoppingDistance,
            float minPointDistance
        )
        {
            this.blackboard = blackboard;
            
            this.followAgent = new Agent_Entity_FollowEntityByPolygon(monoContext);
            this.followAgent.SetStoppingDistance(stoppingDistance);
            this.followAgent.SetMinPointDistance(minPointDistance);
            this.followAgent.SetCalculatePathPeriod(new WaitForFixedUpdate());
            this.followAgent.SetCheckTargetReachedPeriod(null);
        }

        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            if (!this.blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                this.Return(false);
                return;
            }

            if (!this.blackboard.TryGetVariable(this.surfaceKey, out MonoPolygon polygon))
            {
                this.Return(false);
                return;
            }

            this.followAgent.OnTargetReached += this.OnTargetReached;
            this.followAgent.SetSurface(polygon);
            this.followAgent.SetTargetEntity(target);
            this.followAgent.SetFollowingEntity(unit);
            this.followAgent.Play();
        }

        private void OnTargetReached(bool isReached)
        {
            if (isReached)
            {
                this.Return(true);
            }
        }

        protected override void OnEnd()
        {
            this.followAgent.Stop();
            this.followAgent.OnTargetReached -= this.OnTargetReached;
        }
    }
}