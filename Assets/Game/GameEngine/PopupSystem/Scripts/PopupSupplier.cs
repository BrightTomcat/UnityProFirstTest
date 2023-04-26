using System.Collections.Generic;
using GameSystem;
using UIFrames;
using UIFrames.Unity;

namespace Game.GameEngine
{
    public sealed class PopupSupplier : IFrameSupplier<PopupName, UnityFrame>
    {
        private readonly Dictionary<PopupName, UnityFrame> cashedFrames = new();
        
        private IGameContext gameContext;

        private IFrameFactory<PopupName, UnityFrame> factory;

        public void Construct(IGameContext gameContext, IFrameFactory<PopupName, UnityFrame> factory)
        {
            this.gameContext = gameContext;
            this.factory = factory;
        }

        public UnityFrame LoadFrame(PopupName key)
        {
            if (this.cashedFrames.TryGetValue(key, out var popup))
            {
                popup.gameObject.SetActive(true);
            }
            else
            {
                popup = this.factory.CreateFrame(key);
                this.cashedFrames.Add(key, popup);
            }
            
            if (popup.TryGetComponent(out IGameElement gameElement))
            {
                this.gameContext.RegisterElement(gameElement);
            }

            popup.transform.SetAsLastSibling();
            return popup;
        }

        public void UnloadFrame(UnityFrame popup)
        {
            if (popup.TryGetComponent(out IGameElement gameElement))
            {
                this.gameContext.UnregisterElement(gameElement);
            }

            popup.gameObject.SetActive(false);
        }
    }
}