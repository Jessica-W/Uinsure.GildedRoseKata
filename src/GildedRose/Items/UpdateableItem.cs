using System;

namespace GildedRose.Items;

public abstract class UpdateableItem
{
    protected readonly Item Item;

    protected UpdateableItem(Item item)
    {
        Item = item;
    }

    public void ProgressItemLifecycle()
    {
        UpdateItemSellIn();
        UpdateItemQuality();
    }
    
    protected virtual void UpdateItemSellIn()
    {
        Item.SellIn -= 1;
    }
    protected abstract void UpdateItemQuality();
    
    protected void IncreaseItemQuality()
    {
        if (Item.Quality < 50)
        {
            Item.Quality += 1;
        }
    }
    
    protected void DecreaseItemQuality(int amount = 1)
    {
        Item.Quality = Math.Max(0, Item.Quality - amount);
    }
}