namespace GildedRose.Items;

public class AgedItem(Item item) : UpdateableItem(item)
{
    protected override void UpdateItemQuality()
    {
        IncreaseQuality();

        if (Item.SellIn < 0)
        {
            IncreaseQuality();
        }
    }
}