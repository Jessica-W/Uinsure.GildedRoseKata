using System;

namespace GildedRose.Items;

public class StandardItem(Item item) : UpdateableItem(item)
{
    protected override void UpdateItemQuality()
    {
            DecreaseItemQuality();

            if (Item.SellIn < 0)
            {
                DecreaseItemQuality();
            }
    }
}