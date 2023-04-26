using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine
{
    [Serializable]
    public sealed class SoundEmitter : ISoundEmitter
    {
        private AudioSource source;

        private SoundCatalog catalog;

        public void Construct(AudioSource source, SoundCatalog catalog)
        {
            this.source = source;
            this.catalog = catalog;
        }

        [Button]
        [GUIColor(0, 1, 0)]
        public void PlaySound(string id)
        {
            if (this.catalog.FindSound(id, out var sound))
            {
                this.source.PlayOneShot(sound);
            }
        }
    }
}