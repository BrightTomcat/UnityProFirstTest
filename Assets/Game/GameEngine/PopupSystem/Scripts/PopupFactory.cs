using UIFrames;
using UIFrames.Unity;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class PopupFactory : IFrameFactory<PopupName, UnityFrame>
    {
        private PopupCatalog catalog;

        private Transform container;

        public void Construct(PopupCatalog catalog, Transform container)
        {
            this.catalog = catalog;
            this.container = container;
        }

        public UnityFrame CreateFrame(PopupName key)
        {
            var prefab = this.catalog.LoadPrefab(key);
            var popup = GameObject.Instantiate(prefab, this.container);
            return popup;
        }
    }
}