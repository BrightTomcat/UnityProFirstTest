using System;
using DG.Tweening;
using MonoOptimization;
using UnityEngine;

namespace Game.GameEngine
{
    [Serializable]
    public sealed class _UIParryAnimator :
        IEnableComponent,
        IDisableComponent
    {
        [SerializeField]
        private RectTransform moveTransform;

        private Tween parryTween;

        void IEnableComponent.OnEnable()
        {
            this.parryTween = UIAnimations.AnimateParry(this.moveTransform);
        }

        void IDisableComponent.OnDisable()
        {
            this.parryTween.Kill();
        }
    }
}