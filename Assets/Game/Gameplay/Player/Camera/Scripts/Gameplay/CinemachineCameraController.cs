using Cinemachine;
using Game.Gameplay.Hero;
using GameSystem;

namespace Game.Gameplay.Player
{
    public sealed class CinemachineCameraController : 
        IGameStartElement,
        IGameFinishElement
    {
        private CinemachineVirtualCamera virtualCamera;

        private HeroService heroService;
        
        public void Construct(CinemachineVirtualCamera virtualCamera, HeroService heroService)
        {
            this.virtualCamera = virtualCamera;
            this.heroService = heroService;
        }

        void IGameStartElement.StartGame()
        {
            var hero = this.heroService.GetHero();
            this.virtualCamera.Follow = hero.Get<Component_CinemachineFollowPoint>().Point;
            this.virtualCamera.enabled = true;
        }

        void IGameFinishElement.FinishGame()
        {
            this.virtualCamera.enabled = false;
        }
    }
}