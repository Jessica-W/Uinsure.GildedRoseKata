using Xunit;
using System.Collections.Generic;
using GildedRose;

namespace GildedRoseTests
{
    public class GildedRoseInventoryTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new GildedRoseInventory(Items);
            app.UpdateQuality();
            Assert.Equal("fixme", Items[0].Name);
        }
    }
}
