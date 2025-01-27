namespace GildedRose.Items;

public class ConjuredItem : UpdateableItem
{
    public ConjuredItem(Item item) : base(item)
    {
    }

    protected override void UpdateItemQuality()
    {
        DecreaseItemQuality(2);

        if (Item.SellIn < 0)
        {
            DecreaseItemQuality(2);
        }
    }
}