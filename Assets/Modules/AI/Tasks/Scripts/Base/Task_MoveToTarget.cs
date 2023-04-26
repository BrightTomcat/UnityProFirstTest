using System.Collections;
using UnityEngine;

namespace AI.Tasks
{
    public abstract class Task_MoveToTarget<T> : Task_Coroutine
    {
        private readonly YieldInstruction framePeriod;

        private T target;

        public Task_MoveToTarget(
            MonoBehaviour coroutineDispatcher,
            YieldInstruction framePeriod = null
        ) : base(coroutineDispatcher)
        {
            this.framePeriod = framePeriod;
        }

        public void SetTarget(T target)
        {
            this.target = target;
        }

        protected override IEnumerator DoAsync()
        {
            while (!this.CheckTargetReached(this.target))
            {
                this.MoveToTarget(this.target);
                yield return this.framePeriod;
            }

            yield return this.framePeriod; //Костыль...
            this.Return(true);
        }

        protected abstract bool CheckTargetReached(T target);

        protected abstract void MoveToTarget(T target);
    }
}