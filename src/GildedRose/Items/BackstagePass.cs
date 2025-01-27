namespace GildedRose.Items;

public class BackstagePass : UpdateableItem
{
    public BackstagePass(Item item) : base(item)
    {
    }

    protected override void UpdateItemQuality()
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
}