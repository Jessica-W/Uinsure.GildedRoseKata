namespace GildedRose.Items;

public class LegendaryItem(Item item) : UpdateableItem(item)
{
    protected override void UpdateItemSellIn()
    {
        // Never has to be sold
    }

    protected override void UpdateItemQuality()
    {
        // Quality is always 80
        Item.Quality = 80;
    }
}