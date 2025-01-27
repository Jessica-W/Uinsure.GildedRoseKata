using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Items;

namespace GildedRose
{
    public class GildedRoseInventory
    {
        IList<Item> Items;
        private readonly UpdateableItemFactory _updateableItemFactory;

        public GildedRoseInventory(UpdateableItemFactory updateableItemFactory, IList<Item> Items)
        {
            _updateableItemFactory = updateableItemFactory;
            this.Items = Items;
        }

        public void UpdateItem()
        {
            foreach (var item in Items.Select(_updateableItemFactory.UpdateableItemFromItem))
            {
                item.ProgressItemLifecycle();
            }
        }
    }
}