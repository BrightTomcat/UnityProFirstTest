using System;
using Game.GameEngine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class WorldPlaceVisitor : MonoBehaviour
    {
        public event Action<WorldPlaceType> OnVisitStarted;
        
        public event Action<WorldPlaceType> OnVisitEnded;
        
        [ReadOnly]
        [ShowInInspector]
        public bool IsVisiting { get; private set; }

        [ReadOnly]
        [ShowInInspector]
        public WorldPlaceType CurrentPlace { get; private set; }
        
        public void StartVisit(WorldPlaceType type)
        {
            if (this.IsVisiting)
            {
                throw new Exception("Other visit place is already started!");
            }

            this.IsVisiting = true;
            this.CurrentPlace = type;
            this.OnVisitStarted?.Invoke(type);
        }

        public void EndVisit()
        {
            if (!this.IsVisiting)
            {
                return;
            }

            this.IsVisiting = false;
            this.OnVisitEnded?.Invoke(this.CurrentPlace);
        }
    }
}