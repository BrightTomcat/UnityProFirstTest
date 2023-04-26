using Game.App;
using Game.GameEngine.GameResources;
using Services;

namespace Game.Gameplay.Player
{
    public sealed class ResourceMediator : 
        IGameLoadDataListener,
        IGameSaveDataListener
    {
        private ResourceRepository repository;

        private ResourceStorage resourceStorage;

        [ServiceInject]
        public void Construct(ResourceRepository repository)
        {
            this.repository = repository;
        }

        void IGameLoadDataListener.OnLoadData(GameManager gameManager)
        {
            this.resourceStorage = gameManager.GetService<ResourceStorage>();

            var resourcesData = this.LoadResources();
            this.resourceStorage.Setup(resourcesData);
        }

        void IGameSaveDataListener.OnSaveData(GameSaveReason reason)
        {
            var resources = this.resourceStorage.GetAllResources();
            this.repository.SaveResources(resources);
        }

        private ResourceData[] LoadResources()
        {
            if (this.repository.LoadResources(out var resources))
            {
                return resources;
            }

            var config = ResourceStorageConfig.LoadAsset();
            return config.InitialResources;
        }
    }
}