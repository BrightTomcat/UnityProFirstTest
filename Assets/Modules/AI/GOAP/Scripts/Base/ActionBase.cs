namespace AI.GOAP
{
    public abstract class ActionBase : IAction
    {
        public string Name
        {
            get { return this.name; }
        }

        public virtual Parameter[] RequiredState
        {
            get { return this.requiredState; }
            set { this.requiredState = value; }
        }

        public virtual Parameter[] SatisfiedState
        {
            get { return this.satisfiedState; }
            set { this.satisfiedState = value; }
        }

        private readonly string name;

        protected Parameter[] requiredState;

        protected Parameter[] satisfiedState;

        protected ActionBase(
            string name,
            Parameter[] requiredState = null,
            Parameter[] satisfiedState = null
        )
        {
            this.name = name;
            this.requiredState = requiredState;
            this.satisfiedState = satisfiedState;
        }

        public abstract int EvaluateCost();

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