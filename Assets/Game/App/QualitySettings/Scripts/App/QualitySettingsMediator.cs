using Services;

namespace Game.App
{
    public sealed class QualitySettingsMediator :
        IAppInitListener,
        IAppStartListener,
        IAppStopListener
    {
        [ServiceInject]
        private QualitySettingsRepository repository;

        
        void IAppInitListener.Init()
        {
            if (this.repository.LoadSettings(out var data))
            {
                QualitySettingsManager.SetLevel(data.qualityLevel);
            }
        }

        void IAppStartListener.Start()
        {
            QualitySettingsManager.OnLevelChanged += this.SaveSettings;
        }

        void IAppStopListener.Stop()
        {
            QualitySettingsManager.OnLevelChanged -= this.SaveSettings;
        }

        private void SaveSettings(int level)
        {
            var data = new QualitySettingsData
            {
                qualityLevel = level
            };
            this.repository.SaveSettings(data);
        }
    }
}