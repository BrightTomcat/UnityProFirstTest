using Game.App;

namespace Game.Tutorial.App
{
    public sealed class TutorialAnalyticsTracker : IGameStartListener
    {
        void IGameStartListener.OnStartGame(GameManager gameManager)
        {
            var tutorialManager = TutorialManager.Instance;
            if (tutorialManager.IsCompleted)
            {
                return;
            }

            tutorialManager.OnCompleted += this.OnCompleteTutorial;
            TutorialAnalytics.LogTutorialStarted(); //1 раз
        }

        private void OnCompleteTutorial()
        {
            TutorialManager.Instance.OnCompleted -= this.OnCompleteTutorial;
            TutorialAnalytics.LogTutorialCompleted(); //1 раз
        }
    }
}