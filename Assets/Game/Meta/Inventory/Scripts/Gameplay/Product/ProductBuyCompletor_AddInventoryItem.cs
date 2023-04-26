using Game.GameEngine.InventorySystem;
using Game.GameEngine.Products;
using GameSystem;
using UnityEngine;

namespace Game.Meta
{
    public sealed class ProductBuyCompletor_AddInventoryItem : IProductBuyCompletor
    {
        private readonly StackableInventory inventory;

        public ProductBuyCompletor_AddInventoryItem(StackableInventory inventory)
        {
            this.inventory = inventory;
        }

        public void CompleteBuy(Product product)
        {
            if (product.TryGetComponent(out IComponent_InventoryItem component))
            {
                var prototype = component.Item;
                this.inventory.AddItemsByPrototype(prototype, 1);
            }
        }
    }
}