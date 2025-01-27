namespace GildedRose.Items;

public class ConjuredItem(Item item) : UpdateableItem(item)
{
    protected override void UpdateItemQuality()
    {
        DecreaseQuality(2);

        if (Item.SellIn < 0)
        {
            DecreaseQuality(2);
        }
    }
}