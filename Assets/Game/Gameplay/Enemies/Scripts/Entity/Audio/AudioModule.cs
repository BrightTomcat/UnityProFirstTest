using Elementary;
using MonoOptimization;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [AddComponentMenu("Gameplay/Enemies/Enemy Audio Module")]
    public sealed class AudioModule : MonoModule
    {
        [SerializeField]
        private AudioSource audioSource;

        [Space]
        [SerializeField]
        private AudioClip deathSound;

        public override void Construct(MonoContextModular context)
        {
            var coreModule = context.GetModule<CoreModule>();
            coreModule.lifeModule.destroyEmitter.AddListener(new Action_AudioSource_PlayOneShot(
                this.audioSource, this.deathSound
            ));
        }
    }
}