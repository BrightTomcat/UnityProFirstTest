using GameSystem;
using UnityEngine;

namespace Game.Tutorial.Gameplay
{
    public abstract class TutorialCompleteController : MonoBehaviour,
        IGameConstructElement,
        IGameReadyElement,
        IGameFinishElement
    {
        private TutorialManager tutorialManager;

        public virtual void ConstructGame(IGameContext context)
        {
            this.tutorialManager = TutorialManager.Instance;
        }

        public virtual void ReadyGame()
        {
            this.tutorialManager.OnCompleted += this.OnTutorialComplete;
        }

        public virtual void FinishGame()
        {
            this.tutorialManager.OnCompleted -= this.OnTutorialComplete;
        }
        
        protected virtual void OnTutorialComplete()
        {
        }

        public bool IsCompleted()
        {
            return this.tutorialManager.IsCompleted;
        }
    }
}