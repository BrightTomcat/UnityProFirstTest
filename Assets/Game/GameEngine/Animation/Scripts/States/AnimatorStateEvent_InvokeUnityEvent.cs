using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.GameEngine.Animation.Scripts.States
{
    [Serializable]
    public sealed class AnimatorStateEvent_InvokeUnityEvent : AnimatorStateEvent
    {
        [SerializeField]
        private UnityEvent unityEvent;

        protected override void OnEvent()
        {
            this.unityEvent.Invoke();
        }
    }
}