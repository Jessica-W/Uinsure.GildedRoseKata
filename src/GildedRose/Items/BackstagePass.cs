namespace GildedRose.Items;

public class BackstagePass(Item item) : UpdateableItem(item)
{
    protected override void UpdateItemQuality()
    {
        switch (Item.SellIn)
        {
            case < 0:
                Item.Quality = 0;
                break;
            case < 5:
                IncreaseQuality(3);
                break;
            case < 10:
                IncreaseQuality(2);
                break;
            default:
                IncreaseQuality();
                break;
        }
    }
}