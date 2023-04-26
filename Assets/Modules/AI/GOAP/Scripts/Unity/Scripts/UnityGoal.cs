using UnityEngine;

namespace AI.GOAP
{
    [AddComponentMenu("AI/GOAP/Goal")]
    public class UnityGoal : UnityGoalBase
    {
        [Space]
        [SerializeField]
        private int priority;

        [SerializeField]
        private bool isValid;

        public override int EvaluatePriority()
        {
            return this.priority;
        }

        public void SetPriority(int priority)
        {
            this.priority = priority;
        }

        public override bool IsValid()
        {
            return this.isValid;
        }

        public void SetValid(bool isValid)
        {
            this.isValid = isValid;
        }
    }
}