using System;
using System.Collections.Generic;
using GildedRose.Items;

namespace GildedRose
{
    public class GildedRoseInventory
    {
        IList<Item> Items;

        public GildedRoseInventory(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateItem()
        {
            foreach (var item in Items)
            {
                var updateableItem = UpdateableItemFromItem(item);
                updateableItem.ProgressItemLifecycle();
            }
        }

        private UpdateableItem UpdateableItemFromItem(Item item)
        {
            return new UniversalItem(item);
        }
    }
}