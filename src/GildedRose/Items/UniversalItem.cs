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
            UpdateLegendaryItemQuality();
        }
        else if (Item.Name == "Aged Brie")
        {
            UpdateAgedBrieQuality();
        }
        else if (Item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            UpdateBackstagePassQuality();
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

    private void UpdateLegendaryItemQuality()
    {
        Item.Quality = 80;
    }

    private void UpdateStandardItemQuality()
    {
        DecreaseItemQuality();

        if (Item.SellIn < 0)
        {
            DecreaseItemQuality();
        }
    }

    private void UpdateBackstagePassQuality()
    {
        IncreaseItemQuality();

        if (Item.SellIn < 10)
        {
            IncreaseItemQuality();
        }

        if (Item.SellIn < 5)
        {
            IncreaseItemQuality();
        }

        if (Item.SellIn < 0)
        {
            Item.Quality = 0;
        }
    }

    private void UpdateAgedBrieQuality()
    {
        IncreaseItemQuality();

        if (Item.SellIn < 0)
        {
            IncreaseItemQuality();
        }
    }
}