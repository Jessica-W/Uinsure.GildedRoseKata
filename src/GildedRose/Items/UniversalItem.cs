using System;

namespace GildedRose.Items;

public class UniversalItem : UpdateableItem
{
    public UniversalItem(Item item) : base(item)
    {
    }

    protected override void UpdateItemSellIn()
    {
        if (!IsLegendaryItem())
        {
            base.UpdateItemSellIn();
        }
    }

    protected override void UpdateItemQuality()
    {
        if (IsLegendaryItem())
        {
            throw new Exception("No longer handled here");
        }
        else if (Item.Name == "Aged Brie")
        {
            throw new Exception("No longer handled here");
        }
        else if (Item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            throw new Exception("No longer handled here");
        }
        else if (Item.Name.StartsWith("Conjured"))
        {
            UpdateConjuredItemQuality();
        }
        else
        {
            UpdateStandardItemQuality();
        }
    }

    private bool IsLegendaryItem()
    {
        return Item.Name == "Sulfuras, Hand of Ragnaros";
    }

    private void UpdateConjuredItemQuality()
    {
        DecreaseItemQuality(2);

        if (Item.SellIn < 0)
        {
            DecreaseItemQuality(2);
        }
    }

    private void UpdateStandardItemQuality()
    {
        DecreaseItemQuality();

        if (Item.SellIn < 0)
        {
            DecreaseItemQuality();
        }
    }
}