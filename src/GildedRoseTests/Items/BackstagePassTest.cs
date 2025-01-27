using GildedRose;
using GildedRose.Items;
using NUnit.Framework;

namespace GildedRoseTests.Items;

public class BackstagePassTest
{
    [Test]
    public void GivenItem_WhenUpdateItemIsCalled_ThenSellInIsDecreasedByOne()
    {
        // Given
        var item = new Item { SellIn = 99 };
        var unitUnderTest = new BackstagePass(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.SellIn, Is.EqualTo(98));
    }
    
    [TestCase(0)]
    [TestCase(-1)]
    public void GivenItemWithSellInOfZeroOrLess_WhenUpdateItemIsCalled_ThenQualityReducedToZero(int sellIn)
    {
        // Given
        var item = new Item { Quality = 30, SellIn = sellIn };
        var unitUnderTest = new BackstagePass(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(0));
    }
    
    [TestCase(5)]
    [TestCase(4)]
    [TestCase(3)]
    [TestCase(2)]
    [TestCase(1)]
    public void GivenItemWithSellInOfFiveOrLessAndQualityWouldNotExceedFifty_WhenUpdateItemIsCalled_ThenQualityIsIncreasedByThree(int sellIn)
    {
        // Given
        var item = new Item { Quality = 30, SellIn = sellIn };
        var unitUnderTest = new BackstagePass(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(33));
    }
    
    [TestCase(48)]
    [TestCase(49)]
    [TestCase(50)]
    public void GivenItemWithSellInOfFiveOrLessAndQualityWouldExceedFifty_WhenUpdateItemIsCalled_ThenQualityIsIncreasedToFifty(int quality)
    {
        // Given
        var item = new Item { Quality = quality, SellIn = 5 };
        var unitUnderTest = new BackstagePass(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(50));
    }
    
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(10)]
    public void GivenItemWithSellInBetweenSixAndTenAndQualityWouldNotExceedFifty_WhenUpdateItemIsCalled_ThenQualityIsIncreasedByTwo(int sellIn)
    {
        // Given
        var item = new Item { Quality = 30, SellIn = sellIn };
        var unitUnderTest = new BackstagePass(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(32));
    }
    
    [TestCase(49)]
    [TestCase(50)]
    public void GivenItemWithSellInBetweenSixAndTenAndQualityWouldExceedFifty_WhenUpdateItemIsCalled_ThenQualityIsIncreasedToFifty(int quality)
    {
        // Given
        var item = new Item { Quality = quality, SellIn = 10 };
        var unitUnderTest = new BackstagePass(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(50));
    }
    
    [TestCase(48, 49)]
    [TestCase(49, 50)]
    [TestCase(50, 50)]
    public void GivenItemWithSellInGreaterThanTen_WhenUpdateItemIsCalled_ThenQualityIsIncreasedTByOneButCappedAtFifty(int quality, int expectedUpdatedQuality)
    {
        // Given
        var item = new Item { Quality = quality, SellIn = 11 };
        var unitUnderTest = new BackstagePass(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(expectedUpdatedQuality));
    }
}