using System.Collections.Generic;
using Game.App;
using Services;
using UnityEngine;

namespace Game.Meta
{
    public sealed class MisssionsMediator :
        IGameLoadDataListener, 
        IGameSaveDataListener
    {
        [ServiceInject]
        private MissionsAssetSupplier assetSupplier;

        [ServiceInject]
        private MissionsDao dao;

        private MissionsManager missionsManager;

        void IGameLoadDataListener.OnLoadData(GameManager gameManager)
        {
            this.missionsManager = gameManager.GetService<MissionsManager>();
            if (this.dao.SelectMissions(out var missionsData))
            {
                this.SetupMissions(missionsData);
            }
        }

        void IGameSaveDataListener.OnSaveData(GameSaveReason reason)
        {
            this.dao.DeleteMissions();
            this.InsertMissions();
        }

        private void SetupMissions(List<MissionData> missionsData)
        {
            for (int i = 0, count = missionsData.Count; i < count; i++)
            {
                var data = missionsData[i];
                this.SetupMission(data);
            }
        }

        private void SetupMission(MissionData data)
        {
            var config = this.assetSupplier.GetMission(data.id);
            var mission = this.missionsManager.SetupMission(config);
            config.DeserializeTo(data.serializedState, mission);
        }

        private void InsertMissions()
        {
            var actualMissions = this.missionsManager.GetMissions();
            var count = actualMissions.Length;
            var dataArray = new MissionData[count];

            for (var i = 0; i < count; i++)
            {
                var mission = actualMissions[i];
                var data = this.ConvertToData(mission);
                dataArray[i] = data;
            }

            this.dao.InsertMissions(dataArray);
        }

        private MissionData ConvertToData(Mission mission)
        {
            var id = mission.Id;
            var config = this.assetSupplier.GetMission(id);
            var data = new MissionData
            {
                id = id,
                serializedState = config.Serialize(mission)
            };

            return data;
        }
    }
}