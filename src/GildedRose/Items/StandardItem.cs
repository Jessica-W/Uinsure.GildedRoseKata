using System;

namespace GildedRose.Items;

public class StandardItem(Item item) : UpdateableItem(item)
{
    protected override void UpdateItemQuality()
    {
            DecreaseQuality();

            if (Item.SellIn < 0)
            {
                DecreaseQuality();
            }
    }
}