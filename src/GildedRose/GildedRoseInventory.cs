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
            if (item.Name.StartsWith("Aged "))
            {
                return new AgedItem(item);
            }

            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return new LegendaryItem(item);
            }

            if (item.Name.StartsWith("Backstage passes "))
            {
                return new BackstagePass(item);
            }

            if (item.Name.StartsWith("Conjured "))
            {
                return new ConjuredItem(item);
            }

            return new StandardItem(item);
        }
    }
}