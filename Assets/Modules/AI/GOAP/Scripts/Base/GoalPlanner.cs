using System.Collections.Generic;
using System.Linq;

namespace AI.GOAP
{
    public sealed class GoalPlanner : IGoalPlanner
    {
        private readonly IProvider provider;

        public GoalPlanner(IProvider provider)
        {
            this.provider = provider;
        }

        public bool MakePlan(out Plan plan)
        {
            IWorldState worldState = this.provider
                .ProvideWorldState();

            IGoal[] goals = this.provider
                .ProvideAllGoals()
                .Where(it => it.IsValid() &&
                             worldState.ContainsParameters(it.DesiredState)
                )
                .OrderByDescending(it => it.EvaluatePriority())
                .ToArray();

            IAction[] actions = this.provider
                .ProvideAllActions()
                .Where(it => it.IsValid() &&
                             worldState.ContainsParameters(it.RequiredState) &&
                             worldState.ContainsParameters(it.SatisfiedState)
                )
                .ToArray();


            for (int i = 0, count = goals.Length; i < count; i++)
            {
                var goal = goals[i];
                if (PlanAlgorithm.BuildPlan(goal, actions, worldState, out plan))
                {
                    return true;
                }
            }

            plan = default;
            return false;
        }

        public interface IProvider
        {
            IWorldState ProvideWorldState();

            IEnumerable<IGoal> ProvideAllGoals();

            IEnumerable<IAction> ProvideAllActions();
        }
    }
}