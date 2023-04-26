using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class BoolMechanics_ControlColliderSensor : BoolMechanics
    {
        [SerializeField]
        public CollidersSensorBase sensor;

        protected override void SetValue(bool isEnable)
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