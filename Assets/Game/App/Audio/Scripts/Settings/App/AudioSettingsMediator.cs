using Services;

namespace Game.App
{
    public sealed class AudioSettingsMediator : IAppInitListener, IGameSaveDataListener
    {
        [ServiceInject]
        private AudioSettingsRepository repository;

        void IAppInitListener.Init()
        {
            this.LoadSettings();
        }

        void IGameSaveDataListener.OnSaveData(GameSaveReason reason)
        {
            this.SaveSettings();
        }

        private void LoadSettings()
        {
            if (this.repository.LoadSettings(out AudioSettingsData data))
            {
                AudioSettingsManager.SetMusicVolume(data.musicVolume);
                AudioSettingsManager.SetSoundVolume(data.soundVolume);
            }
            else
            {
                AudioSettingsManager.SetMusicVolumeDefault();
                AudioSettingsManager.SetSoundVolumeDefault();
            }
        }

        private void SaveSettings()
        {
            AudioSettingsData data = new AudioSettingsData
            {
                musicVolume = AudioSettingsManager.MusicVolume,
                soundVolume = AudioSettingsManager.SoundVolume
            };
            this.repository.SaveSettings(data);
        }
    }
}