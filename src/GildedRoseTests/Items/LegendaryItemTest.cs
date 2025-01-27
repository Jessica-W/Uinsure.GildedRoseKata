using GildedRose;
using GildedRose.Items;
using NUnit.Framework;

namespace GildedRoseTests.Items;

public class LegendaryItemTest
{
    [Test]
    public void GivenItem_WhenUpdateItemIsCalled_ThenSellInIsUnchangedAndQualityIsEighty()
    {
        // Given
        var item = new Item { Quality = 40, SellIn = 10 };
        var unitUnderTest = new LegendaryItem(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.SellIn, Is.EqualTo(10));
        Assert.That(item.Quality, Is.EqualTo(80));
    }
}