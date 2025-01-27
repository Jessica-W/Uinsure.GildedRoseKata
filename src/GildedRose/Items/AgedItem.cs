namespace GildedRose.Items;

public class AgedItem : UpdateableItem
{
    public AgedItem(Item item) : base(item)
    {
    }

    protected override void UpdateItemQuality()
    {
        IncreaseItemQuality();

        if (Item.SellIn < 0)
        {
            IncreaseItemQuality();
        }
    }
}