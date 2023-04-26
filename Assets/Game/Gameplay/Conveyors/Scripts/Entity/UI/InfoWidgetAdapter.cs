using System;
using Elementary;
using MonoOptimization;

namespace Game.Gameplay.Conveyors
{
    [Serializable]
    public sealed class InfoWidgetAdapter : 
        IAwakeComponent,
        IEnableComponent,
        IDisableComponent
    {
        private ITimer workTimer;
        
        private InfoWidget view;

        public void Construct(ITimer workTimer, InfoWidget view)
        {
            this.workTimer = workTimer;
            this.view = view;
        }

        void IAwakeComponent.Awake()
        {
            this.view.SetVisible(true);
            this.view.ProgressBar.SetVisible(this.workTimer.IsPlaying);
        }

        void IEnableComponent.OnEnable()
        {
            this.workTimer.OnStarted += this.OnWorkStarted;
            this.workTimer.OnTimeChanged += this.OnWorkProgressChanged;
            this.workTimer.OnFinished += this.OnWorkFinished;
        }

        void IDisableComponent.OnDisable()
        {
            this.workTimer.OnStarted -= this.OnWorkStarted;
            this.workTimer.OnTimeChanged -= this.OnWorkProgressChanged;
            this.workTimer.OnFinished -= this.OnWorkFinished;
        }

        private void OnWorkStarted()
        {
            this.view.ProgressBar.SetVisible(true);
        }

        private void OnWorkProgressChanged()
        {
            this.view.ProgressBar.SetProgress(this.workTimer.Progress);
        }

        private void OnWorkFinished()
        {
            this.view.ProgressBar.SetVisible(false);
        }
    }
}