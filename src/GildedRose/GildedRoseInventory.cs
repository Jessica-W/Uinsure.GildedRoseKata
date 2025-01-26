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

                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    DecreaseItemQuality(item);
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;

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
                }

                item.SellIn -= 1;

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            DecreaseItemQuality(item);
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        IncreaseItemQuality(item);
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