using Game.GameAudio;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class HarvestResourceAction_PlaySound : IHarvestResourceAction 
    {
        private readonly AudioClip collectSFX;

        public HarvestResourceAction_PlaySound(AudioClip collectSfx)
        {
            this.collectSFX = collectSfx;
        }

        public void Do(HarvestResourceOperation operation)
        {
            if (operation.isCompleted)
            {
                GameAudioManager.PlaySound(GameAudioType.INTERFACE, this.collectSFX);
            }
        }
    }
}