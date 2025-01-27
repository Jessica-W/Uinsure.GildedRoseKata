using GildedRose;
using GildedRose.Items;
using NUnit.Framework;

namespace GildedRoseTests.Items;

public class AgedItemTest
{
    [TestCase(1)]
    [TestCase(0)]
    public void GivenItem_WhenUpdateItemIsCalled_ThenSellInIsDecreasedByOne(int initialSellIn)
    {
        // Given
        var item = new Item { SellIn = initialSellIn };
        var unitUnderTest = new AgedItem(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.SellIn, Is.EqualTo(initialSellIn - 1));
    }
    
    [Test]
    public void GivenItemWhichIsNotPastItsSellByWithQualityGreaterThanZero_WhenUpdateItemIsCalled_ThenQualityIsIncreasedByOne()
    {
        // Given
        var item = new Item { Quality = 5, SellIn = 1 };
        var unitUnderTest = new AgedItem(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(6));
    }
    
    [TestCase(0)]
    [TestCase(-1)]
    public void GivenItemWhichIsPastItsSellByWithQualityGreaterThanOne_WhenUpdateItemIsCalled_ThenQualityIsIncreasedByTwo(int sellIn)
    {
        // Given
        var item = new Item { Quality = 5, SellIn = sellIn };
        var unitUnderTest = new AgedItem(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(7));
    }
    
    [TestCase(0)]
    [TestCase(-1)]
    public void GivenItemWhichIsPastItsSellByWithQualityOfFortyNine_WhenUpdateItemIsCalled_ThenQualityIsIncreasedToFifty(int sellIn)
    {
        // Given
        var item = new Item { Quality = 49, SellIn = sellIn };
        var unitUnderTest = new AgedItem(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(50));
    }
}