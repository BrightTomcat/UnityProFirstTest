using Entities;
using Game.App;
using Game.GameEngine.Mechanics;
using Services;

namespace Game.Gameplay.Conveyors
{
    public sealed class ConveyorsMediator : IGameLoadDataListener, IGameSaveDataListener
    {
        [ServiceInject]
        private ConveyorsRepository repository;

        private ConveyorsService conveyorsService;

        void IGameLoadDataListener.OnLoadData(GameManager gameManager)
        {
            this.conveyorsService = gameManager.GetService<ConveyorsService>();
            if (this.repository.LoadConveyors(out var conveyorsData))
            {
                this.SetupConveyours(conveyorsData);
            }
        }

        void IGameSaveDataListener.OnSaveData(GameSaveReason reason)
        {
            this.SaveConveyours();
        }

        private void SetupConveyours(ConveyorData[] conveyorsData)
        {
            for (int i = 0, count = conveyorsData.Length; i < count; i++)
            {
                var data = conveyorsData[i];
                this.SetupConveyor(data);
            }
        }

        private void SetupConveyor(ConveyorData data)
        {
            var conveyor = this.conveyorsService.FindConveyor(data.id);
            conveyor
                .Get<IComponent_LoadZone>()
                .SetupAmount(data.inputAmount);
            conveyor
                .Get<IComponent_UnloadZone>()
                .SetupAmount(data.outputAmount);
        }

        private void SaveConveyours()
        {
            var conveyors = this.conveyorsService.GetAllConveyors();
            var count = conveyors.Length;
            var dataArray = new ConveyorData[count];

            for (var i = 0; i < count; i++)
            {
                var conveyor = conveyors[i];
                var data = ConvertToData(conveyor);
                dataArray[i] = data;
            }

            this.repository.SaveConveyors(dataArray);
        }

        private static ConveyorData ConvertToData(IEntity conveyor)
        {
            var data = new ConveyorData
            {
                id = conveyor.Get<IComponent_GetId>().Id,
                inputAmount = conveyor.Get<IComponent_LoadZone>().CurrentAmount,
                outputAmount = conveyor.Get<IComponent_UnloadZone>().CurrentAmount
            };
            return data;
        }
    }
}