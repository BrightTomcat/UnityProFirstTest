using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Tasks
{
    public abstract class Task_MoveByPoints<T> : Task_Coroutine
    {
        private const int DEFAULT_POINTS_BUFFER = 16;

        private readonly List<T> currentPath;

        private readonly YieldInstruction framePeriod;

        public Task_MoveByPoints(
            MonoBehaviour coroutineDispatcher,
            YieldInstruction framePeriod = null,
            int bufferSize = DEFAULT_POINTS_BUFFER
        ) : base(coroutineDispatcher)
        {
            this.currentPath = new List<T>(bufferSize);
            this.framePeriod = framePeriod;
        }

        public void SetPath(IEnumerable<T> points)
        {
            this.currentPath.Clear();
            this.currentPath.AddRange(points);
        }

        protected override IEnumerator DoAsync()
        {
            for (var i = 0; i < this.currentPath.Count; i++)
            {
                var nextPoint = this.currentPath[i];
                yield return this.MoveToNextPoint(nextPoint);
            }

            yield return this.framePeriod; //Костыль...
            this.Return(true);
        }

        private IEnumerator MoveToNextPoint(T target)
        {
            while (!this.CheckPointReached(target))
            {
                this.MoveToPoint(target);
                yield return this.framePeriod;
            }
        }

        protected abstract bool CheckPointReached(T target);

        protected abstract void MoveToPoint(T target);
    }
}