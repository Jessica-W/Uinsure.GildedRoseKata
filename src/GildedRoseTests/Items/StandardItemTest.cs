using GildedRose;
using GildedRose.Items;
using NUnit.Framework;

namespace GildedRoseTests.Items;

public class StandardItemTest
{
    [TestCase(1)]
    [TestCase(0)]
    public void GivenItem_WhenUpdateItemIsCalled_ThenSellInIsDecreasedByOne(int initialSellIn)
    {
        // Given
        var item = new Item { Quality = 5, SellIn = initialSellIn };
        var classUnderTest = new StandardItem(item);

        // When
        classUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.SellIn, Is.EqualTo(initialSellIn - 1));
    }
    
    [Test]
    public void GivenItemWhichIsNotPastItsSellByWithQualityGreaterThanZero_WhenUpdateItemIsCalled_ThenQualityIsDecreasedByOne()
    {
        // Given
        var item = new Item { Quality = 5, SellIn = 1 };
        var classUnderTest = new StandardItem(item);

        // When
        classUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(4));
    }
    
    [TestCase(0)]
    [TestCase(-1)]
    public void GivenItemWhichIsPastItsSellByWithQualityGreaterThanOne_WhenUpdateItemIsCalled_ThenQualityIsDecreasedByTwo(int sellIn)
    {
        // Given
        var item = new Item { Quality = 5, SellIn = sellIn };
        var classUnderTest = new StandardItem(item);

        // When
        classUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(3));
    }
    
    [TestCase(0)]
    [TestCase(-1)]
    public void GivenItemWhichIsPastItsSellByWithQualityOfOne_WhenUpdateItemIsCalled_ThenQualityIsDecreasedToZero(int sellIn)
    {
        // Given
        var item = new Item { Quality = 1, SellIn = sellIn };
        var classUnderTest = new StandardItem(item);

        // When
        classUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(0));
    }
}