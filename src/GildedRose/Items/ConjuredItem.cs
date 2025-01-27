namespace GildedRose.Items;

public class ConjuredItem(Item item) : UpdateableItem(item)
{
    protected override void UpdateItemQuality()
    {
        DecreaseItemQuality(2);

        if (Item.SellIn < 0)
        {
            DecreaseItemQuality(2);
        }
    }
}