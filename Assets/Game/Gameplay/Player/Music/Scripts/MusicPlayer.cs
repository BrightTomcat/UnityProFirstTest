using System.Collections;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class MusicPlayer : MonoBehaviour,
        IGameReadyElement,
        IGameStartElement,
        IGamePauseElement,
        IGameResumeElement,
        IGameFinishElement
    {
        [SerializeField]
        private MusicConfig config;

        private int trackPointer;

        void IGameReadyElement.ReadyGame()
        {
            MusicManager.OnFinsihed += this.OnMusicFinished;
        }

        void IGameStartElement.StartGame()
        {
            var track = this.config.tracks[this.trackPointer];
            MusicManager.Play(track);
        }

        void IGamePauseElement.PauseGame()
        {
            MusicManager.Pause();
        }

        void IGameResumeElement.ResumeGame()
        {
            MusicManager.Resume();
        }

        void IGameFinishElement.FinishGame()
        {
            MusicManager.OnFinsihed -= this.OnMusicFinished;
        }

        private void OnMusicFinished()
        {
            this.trackPointer++;
            if (this.trackPointer >= this.config.tracks.Length)
            {
                this.trackPointer = 0;
            }

            this.StartCoroutine(this.PlayNextTrack());
        }

        private IEnumerator PlayNextTrack()
        {
            yield return new WaitForSeconds(this.config.pauseBetweenTracks);
            var nextTrack = this.config.tracks[this.trackPointer];
            MusicManager.Play(nextTrack);
        }
    }
}