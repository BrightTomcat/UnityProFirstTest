using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class BoolAction_PlayStopColliderSensor : IAction<bool>
    {
        [SerializeField]
        public CollidersSensorBase sensor;

        public BoolAction_PlayStopColliderSensor()
        {
        }

        public BoolAction_PlayStopColliderSensor(CollidersSensorBase sensor)
        {
            this.sensor = sensor;
        }

        public void Do(bool isEnable)
        {
            if (isEnable && !this.sensor.IsPlaying)
            {
                this.sensor.Play();
                return;
            }

            if (!isEnable && this.sensor.IsPlaying)
            {
                this.sensor.Stop();
            }
        }
    }
}