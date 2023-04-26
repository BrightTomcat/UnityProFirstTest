using System.Collections.Generic;
using UnityEngine;

namespace AI.GOAP
{
    public static class PlanAlgorithm
    {
        public static bool BuildPlan(IGoal goal, IAction[] actions, IWorldState worldState, out Plan plan)
        {
            var targetParameters = goal.DesiredState;
            if (worldState.MatchesWithParameters(targetParameters))
            {
                plan = new Plan(goal, new IAction[0]);
                return true;
            }

            var actionList = new List<IAction>();
            while (FindCheapestAction(targetParameters, actions, out var nextAction))
            {
                actionList.Add(nextAction);
                targetParameters = nextAction.RequiredState;

                if (worldState.MatchesWithParameters(targetParameters))
                {
                    //Result:
                    actionList.Reverse();
                    plan = new Plan(goal, actionList.ToArray());
                    return true;
                }
                else
                {
                    Debug.Log($"NOT MATCH TARGET PARAMS {targetParameters}");

                }
                
                
            }

            plan = default;
            return false;
        }
        
        //TODO: FindCheapestActionAStar(Parameter[] requiredParameters, IAction[] actions, out IAction result)
        //2^N 
        
        public static bool FindCheapestAction(Parameter[] requiredParameters, IAction[] actions, out IAction result)
        {
            result = null;
            var currentCost = int.MaxValue;

            for (int i = 0, count = actions.Length; i < count; i++)
            {
                var action = actions[i];
                if (!action.SatisfiedState.Includes(requiredParameters))
                {
                    continue;
                }

                var cost = action.EvaluateCost();
                if (result == null || currentCost > cost)
                {
                    result = action;
                    currentCost = cost;
                    Debug.Log($"CHEAPEST ACTION {action.Name}");
                }
            }

            return result != null;
        }
    }
}