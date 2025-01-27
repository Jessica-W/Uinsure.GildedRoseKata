using GildedRose.Items;

namespace GildedRose;

public class UpdateableItemFactory
{
    public UpdateableItem UpdateableItemFromItem(Item item)
    {
        if (item.Name.StartsWith("Aged "))
        {
            return new AgedItem(item);
        }

        if (item.Name == "Sulfuras, Hand of Ragnaros")
        {
            return new LegendaryItem(item);
        }

        if (item.Name.StartsWith("Backstage passes "))
        {
            return new BackstagePass(item);
        }

        if (item.Name.StartsWith("Conjured "))
        {
            return new ConjuredItem(item);
        }

        return new StandardItem(item);
    }
}