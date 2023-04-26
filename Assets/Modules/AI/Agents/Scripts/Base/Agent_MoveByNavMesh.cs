using System;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Agents
{
    public abstract class Agent_MoveByNavMesh : Agent
    {
        public event Action OnPositionReached
        {
            add { this.MoveAgent.OnPathFinished += value; }
            remove { this.MoveAgent.OnPathFinished -= value; }
        }

        public bool IsPathFinished
        {
            get { return this.MoveAgent.IsPathFinished; }
        }

        protected abstract Agent_MoveByPoints<Vector3> MoveAgent { get; }

        private readonly NavMeshPath currentPath;

        private int navMeshAreas;

        protected Agent_MoveByNavMesh()
        {
            this.currentPath = new NavMeshPath();
        }

        public void SetNavMeshAreas(int navMeshAreas)
        {
            this.navMeshAreas = navMeshAreas;
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            if (NavMesh.CalculatePath(this.EvaluateCurrentPosition(), targetPosition, this.navMeshAreas, this.currentPath))
            {
                this.MoveAgent.SetPath(this.currentPath.corners);
            }
            else
            {
                Debug.LogWarning($"Can not calculate path to {targetPosition}");
            }
        }

        protected override void OnStart()
        {
            this.MoveAgent.Play();
        }

        protected override void OnStop()
        {
            this.MoveAgent.Stop();
        }

        protected abstract Vector3 EvaluateCurrentPosition();
    }
}