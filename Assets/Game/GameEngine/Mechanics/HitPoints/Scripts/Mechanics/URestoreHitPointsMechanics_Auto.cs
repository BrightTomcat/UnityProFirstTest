using Elementary;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Hit Points/Mechanics «Restore Hit Points Auto»")]
    public sealed class URestoreHitPointsMechanics_Auto : MonoBehaviour
    {
        [SerializeField]
        public UTakeDamageEngine takeDamageEngine;

        [SerializeField]
        public UHitPointsEngine hitPointsEngine;

        [SerializeField]
        [FormerlySerializedAs("countdown")]
        public MonoCountdown delay;
    
        [SerializeField]
        public MonoPeriod restorePeriod;

        [Space]
        [SerializeField]
        public IntAdapter restoreHitPoinsPerOne;

        private void OnEnable()
        {
            this.takeDamageEngine.OnDamageTaken += this.OnDamageTaken;
            this.delay.OnEnded += this.OnDelayEnded;
            this.restorePeriod.OnPeriodEvent += this.OnRestoreHitPoints;
        }

        private void OnDisable()
        {
            this.takeDamageEngine.OnDamageTaken -= this.OnDamageTaken;
            this.delay.OnEnded -= this.OnDelayEnded;
            this.restorePeriod.OnPeriodEvent -= this.OnRestoreHitPoints;
        }

        private void OnDamageTaken(TakeDamageArgs damageArgs)
        {
            if (this.hitPointsEngine.CurrentHitPoints <= 0)
            {
                return;
            }
            
            //Сброс задержки:
            this.delay.ResetTime();
            if (!this.delay.IsPlaying)
            {
                this.delay.Play();
            }
            
            //Сброс периода:
            this.restorePeriod.Stop();
        }

        private void OnDelayEnded()
        {
            this.restorePeriod.Play();
        }

        private void OnRestoreHitPoints()
        {
            this.hitPointsEngine.CurrentHitPoints += this.restoreHitPoinsPerOne.Current;
            if (this.hitPointsEngine.CurrentHitPoints >= this.hitPointsEngine.MaxHitPoints)
            {
                this.restorePeriod.Stop();
            }
        }
    }
}