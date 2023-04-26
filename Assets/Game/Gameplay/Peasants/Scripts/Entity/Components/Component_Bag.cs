using System;
using Game.GameEngine.GameResources;
using UnityEngine;

namespace Game.Gameplay.Peasants
{
    public sealed class Component_Bag : MonoBehaviour
    {
        public event Action<ResourceType, int> OnResourcesChanged
        {
            add { this.table.OnValueChanged += value; }
            remove { this.table.OnValueChanged -= value; }
        }

        [SerializeField]
        private UResourceSource table;

        public int GetResources(ResourceType type)
        {
            return this.table[type];
        }

        public ResourceData[] GetAllResources()
        {
            return this.table.GetAll();
        }

        public void PutResources(ResourceType type, int amount)
        {
            this.table.Plus(type, amount);
        }

        public void ExtractResources(ResourceType type, int amount)
        {
            this.table.Minus(type, amount);
        }
    }
}