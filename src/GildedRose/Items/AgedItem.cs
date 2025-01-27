namespace GildedRose.Items;

public class AgedItem(Item item) : UpdateableItem(item)
{
    protected override void UpdateItemQuality()
    {
        IncreaseItemQuality();

        if (Item.SellIn < 0)
        {
            IncreaseItemQuality();
        }
    }
}