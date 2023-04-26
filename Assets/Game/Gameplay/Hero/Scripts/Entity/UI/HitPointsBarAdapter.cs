using System.Collections;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [AddComponentMenu("Gameplay/Hero/Hit Points Bar Adapter «Hero»")]
    public sealed class HitPointsBarAdapter : MonoBehaviour
    {
        [SerializeField]
        private UHitPointsEngine hitPointsEngine;

        [SerializeField]
        private HitPointsBar view;

        private Coroutine hideCoroutine;

        private void Awake()
        {
            this.SetupBar();
        }

        private void OnEnable()
        {
            this.hitPointsEngine.OnSetuped += this.SetupBar;
            this.hitPointsEngine.OnHitPointsChanged += this.UpdateBar;
        }

        private void OnDisable()
        {
            this.hitPointsEngine.OnSetuped -= this.SetupBar;
            this.hitPointsEngine.OnHitPointsChanged -= this.UpdateBar;
        }

        private void SetupBar()
        {
            this.ResetCoroutines();

            var hitPoints = this.hitPointsEngine.CurrentHitPoints;
            var maxHitPoints = this.hitPointsEngine.MaxHitPoints;
            
            var showBar = hitPoints > 0 && hitPoints < maxHitPoints;
            this.view.SetVisible(showBar);
            this.view.SetHitPoints(hitPoints, maxHitPoints);
        }

        private void UpdateBar(int hitPoints)
        {
            this.ResetCoroutines();

            var maxHitPoints = this.hitPointsEngine.MaxHitPoints;
            
            this.view.SetVisible(true);
            this.view.SetHitPoints(hitPoints, maxHitPoints);

            if (hitPoints <= 0 || hitPoints == maxHitPoints)
            {
                this.hideCoroutine = this.StartCoroutine(this.HideWithDelay());
            }
        }
        
        private void ResetCoroutines()
        {
            if (this.hideCoroutine != null)
            {
                this.StopCoroutine(this.hideCoroutine);
                this.hideCoroutine = null;
            }
        }

        private IEnumerator HideWithDelay()
        {
            yield return new WaitForSeconds(1.0f);
            this.view.SetVisible(false);
            this.hideCoroutine = null;
        }
    }
}