using UnityEngine;

namespace AI.GOAP
{
    [AddComponentMenu("AI/GOAP/Action")]
    public class UnityAction : UnityActionBase
    {
        [Space]
        [SerializeField]
        private int cost;

        [SerializeField]
        private bool isValid;
        
        public override int EvaluateCost()
        {
            return this.cost;
        }

        public void SetCost(int cost)
        {
            this.cost = cost;
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