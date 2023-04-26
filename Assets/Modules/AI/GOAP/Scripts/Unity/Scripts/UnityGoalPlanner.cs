using System.Collections.Generic;
using UnityEngine;

namespace AI.GOAP
{
    [AddComponentMenu("AI/GOAP/Goal Planner")]
    [DisallowMultipleComponent]
    public sealed class UnityGoalPlanner : MonoBehaviour, IGoalPlanner, GoalPlanner.IProvider
    {
        [SerializeField]
        private UnityWorldState worldState;

        [Space]
        [SerializeField]
        private UnityGoalBase[] goals;

        [Space]
        [SerializeField]
        private UnityActionBase[] actions;

        private readonly GoalPlanner planner;
        
        public bool MakePlan(out Plan plan)
        {
            return this.planner.MakePlan(out plan);
        }

        IWorldState GoalPlanner.IProvider.ProvideWorldState()
        {
            return this.worldState;
        }

        IEnumerable<IGoal> GoalPlanner.IProvider.ProvideAllGoals()
        {
            return this.goals;
        }

        IEnumerable<IAction> GoalPlanner.IProvider.ProvideAllActions()
        {
            return this.actions;
        }

        public UnityGoalPlanner()
        {
            this.planner = new GoalPlanner(provider: this);
        }

#if UNITY_EDITOR
        public UnityActionBase[] Editor_GetActions()
        {
            return this.actions;
        }

        public UnityGoalBase[] Editor_GetGoals()
        {
            return this.goals;
        }
#endif
    }
}