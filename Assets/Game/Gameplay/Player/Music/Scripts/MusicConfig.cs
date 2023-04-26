using UnityEngine;

namespace Game.Gameplay.Player
{
    [CreateAssetMenu(
        fileName = "MusicConfig",
        menuName = "Gameplay/Audio/New MusicConfig"
    )]
    public sealed class MusicConfig : ScriptableObject
    {
        [SerializeField]
        public AudioClip[] tracks;

        [SerializeField]
        public float pauseBetweenTracks = 2.0f;
        
        //Затухание, коэффициенты и.т.д.
    }
}