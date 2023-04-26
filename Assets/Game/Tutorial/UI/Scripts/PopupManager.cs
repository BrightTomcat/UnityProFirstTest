using System;
using GameSystem;
using UIFrames;
using UIFrames.Unity;
using UnityEngine;

namespace Game.Tutorial.UI
{
    public sealed class PopupManager : MonoBehaviour, IFrame.Callback, IGameAttachElement
    {
        private IGameContext gameContext;

        [SerializeField]
        private Transform rootTransform;

        private Action callback;

        private UnityFrame currentPopup;

        public void Show(UnityFrame prefab, object args = null, Action callback = null)
        {
            if (this.currentPopup != null)
            {
                return;
            }

            this.callback = callback;
            this.currentPopup = Instantiate(prefab, this.rootTransform);

            if (this.currentPopup.TryGetComponent(out IGameElement element))
            {
                this.gameContext.RegisterElement(element);
            }

            this.currentPopup.Show(args, callback: this);
        }

        void IFrame.Callback.OnClose(IFrame popup)
        {
            this.currentPopup.Hide();
            
            if (this.currentPopup.TryGetComponent(out IGameElement element))
            {
                this.gameContext.UnregisterElement(element);
            }
            
            Destroy(this.currentPopup.gameObject);
            this.currentPopup = null;
            this.callback?.Invoke();
        }

        void IGameAttachElement.AttachGame(IGameContext context)
        {
            this.gameContext = context;
        }
    }
}