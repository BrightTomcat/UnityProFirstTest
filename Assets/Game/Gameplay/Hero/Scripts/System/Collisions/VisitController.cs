using System;
using System.Collections;
using Elementary;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public abstract class VisitController<T> : TriggerObserver<T> where T : class
    {
        protected MonoBehaviour monoContext;
        
        [Space]
        [ReadOnly]
        [ShowInInspector]
        private T target;

        [ReadOnly]
        [ShowInInspector]
        protected bool IsVisiting { get; private set; }

        [SerializeField]
        private float checkConditionPeriod = 0.1f;

        private Coroutine checkVisitRoutine;

        protected abstract bool IsTargetEntered(T target);

        protected abstract ICondition ProvideVisitCondition(T target);

        [GameInject]
        public void Construct(MonoBehaviour monoContext)
        {
            this.monoContext = monoContext;
        }

        protected sealed override void OnHeroEntered(T target)
        {
            if (this.target != null || !this.IsTargetEntered(target))
            {
                return;
            }

            this.target = target;
            this.checkVisitRoutine = this.monoContext.StartCoroutine(this.CheckVisitRoutine(target));
        }

        protected sealed override void OnHeroExited(T target)
        {
            if (!ReferenceEquals(this.target, target))
            {
                return;
            }

            if (this.checkVisitRoutine != null)
            {
                this.monoContext.StopCoroutine(this.checkVisitRoutine);
                this.checkVisitRoutine = null;
            }

            if (this.IsVisiting)
            {
                this.IsVisiting = false;
                this.OnHeroQuit(this.target);
            }

            this.target = null;
        }

        protected virtual void OnHeroVisit(T target)
        {
        }

        protected virtual void OnHeroQuit(T target)
        {
        }

        private IEnumerator CheckVisitRoutine(T target)
        {
            WaitForSeconds period = null;
            if (this.checkConditionPeriod > 0.0f)
            {
                period = new WaitForSeconds(this.checkConditionPeriod);
            }

            var visitCondition = this.ProvideVisitCondition(target);

            while (true)
            {
                var visitStarted = visitCondition.IsTrue();
                if (visitStarted && !this.IsVisiting)
                {
                    this.IsVisiting = true;
                    this.OnHeroVisit(this.target);
                }
                else if (!visitStarted && this.IsVisiting)
                {
                    this.IsVisiting = false;
                    this.OnHeroQuit(this.target);
                    visitCondition = this.ProvideVisitCondition(target);
                }

                yield return period;
            }
        }
    }
}