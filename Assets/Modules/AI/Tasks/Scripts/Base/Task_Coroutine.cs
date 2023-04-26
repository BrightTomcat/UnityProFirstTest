using System.Collections;
using UnityEngine;

namespace AI.Tasks
{
    public abstract class Task_Coroutine : Task
    {
        private readonly MonoBehaviour coroutineDispatcher;

        private Coroutine coroutine;

        public Task_Coroutine(MonoBehaviour coroutineDispatcher)
        {
            this.coroutineDispatcher = coroutineDispatcher;
        }

        protected override void Do()
        {
            this.coroutine = this.coroutineDispatcher.StartCoroutine(this.DoAsync());            
        }

        protected override void OnCancel()
        {
            if (this.coroutine != null)
            {
                this.coroutineDispatcher.StopCoroutine(this.coroutine);
                this.coroutine = null;
            }
        }

        protected abstract IEnumerator DoAsync();
    }
}