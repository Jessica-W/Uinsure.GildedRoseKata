using System;

namespace GildedRose.Items;

public abstract class UpdateableItem
{
    private const int MaxItemQuality = 50;
    
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
    
    protected void IncreaseQuality(int amount = 1)
    {
        Item.Quality = Math.Min(MaxItemQuality, Item.Quality + amount);
    }
    
    protected void DecreaseQuality(int amount = 1)
    {
        Item.Quality = Math.Max(0, Item.Quality - amount);
    }
}