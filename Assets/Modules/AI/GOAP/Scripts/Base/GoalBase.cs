namespace AI.GOAP
{
    public abstract class GoalBase : IGoal
    {
        public string Name
        {
            get { return this.name; }
        }

        public Parameter[] DesiredState
        {
            get { return this.desiredState; }
            set { this.desiredState = value; }
        }

        private readonly string name;

        protected Parameter[] desiredState;

        public GoalBase(string name, Parameter[] desiredState = null)
        {
            this.name = name;
            this.desiredState = desiredState;
        }

        public abstract int EvaluatePriority();

        public virtual bool IsValid()
        {
            return true;
        }

        public override string ToString()
        {
            return $"{this.name}";
        }
    }
}