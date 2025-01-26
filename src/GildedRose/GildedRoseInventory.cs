using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRoseInventory
    {
        IList<Item> Items;

        public GildedRoseInventory(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                if (item.Name is "Aged Brie" or "Backstage passes to a TAFKAL80ETC concert")
                {
                    IncreaseItemQuality(item);

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            IncreaseItemQuality(item);
                        }

                        if (item.SellIn < 6)
                        {
                            IncreaseItemQuality(item);
                        }
                    }
                }
                else
                {
                    DecreaseItemQuality(item);
                }

                item.SellIn -= 1;

                if (item.SellIn < 0)
                {
                    if (item.Name == "Aged Brie")
                    {
                        IncreaseItemQuality(item);
                    }
                    else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        item.Quality = 0;
                    }
                    else
                    {
                        DecreaseItemQuality(item);
                    }
                }
            }
        }

        private void IncreaseItemQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }

        private void DecreaseItemQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
    }
}