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

        public void UpdateItem()
        {
            foreach (var item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    UpdateLegendaryItemQuality(item);
                    continue;
                }

                item.SellIn -= 1;

                if (item.Name == "Aged Brie")
                {
                    UpdateAgedBrieQuality(item);
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateBackstagePassQuality(item);
                }
                else
                {
                    UpdateStandardItemQuality(item);
                }
            }
        }

        private static void UpdateLegendaryItemQuality(Item item)
        {
            item.Quality = 80;
        }

        private void UpdateStandardItemQuality(Item item)
        {
            DecreaseItemQuality(item);

            if (item.SellIn < 0)
            {
                DecreaseItemQuality(item);
            }
        }

        private void UpdateBackstagePassQuality(Item item)
        {
            IncreaseItemQuality(item);

            if (item.SellIn < 10)
            {
                IncreaseItemQuality(item);
            }

            if (item.SellIn < 5)
            {
                IncreaseItemQuality(item);
            }

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }

        private void UpdateAgedBrieQuality(Item item)
        {
            IncreaseItemQuality(item);

            if (item.SellIn < 0)
            {
                IncreaseItemQuality(item);
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