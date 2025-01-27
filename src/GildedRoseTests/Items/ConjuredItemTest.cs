using GildedRose;
using GildedRose.Items;
using NUnit.Framework;

namespace GildedRoseTests.Items;

public class ConjuredItemTest
{
    [Test]
    public void
        GivenConjuredItemWhichIsNotPastItsSellByWithQualityGreaterThanOne_WhenUpdateItemIsCalled_ThenQualityIsDecreasedByTwo()
    {
        // Given
        var item = new Item { Quality = 3, SellIn = 1 };
        var unitUnderTest = new ConjuredItem(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(1));
    }

    [Test]
    public void
        GivenConjuredItemWhichIsNotPastItsSellByWithQualityOfOne_WhenUpdateItemIsCalled_ThenQualityIsDecreasedToZero()
    {
        // Given
        var item = new Item { Quality = 1, SellIn = 1 };
        var unitUnderTest = new ConjuredItem(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(0));
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void
        GivenConjuredItemWhichIsPastItsSellByWithQualityGreaterThanThree_WhenUpdateItemIsCalled_ThenQualityIsDecreasedByFour(int sellIn)
    {
        // Given
        var item = new Item { Quality = 5, SellIn = sellIn };
        var unitUnderTest = new ConjuredItem(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(1));
    }

    [TestCase(0, 1)]
    [TestCase(-1, 1)]
    [TestCase(0, 2)]
    [TestCase(-1, 2)]
    [TestCase(0, 3)]
    [TestCase(-1, 3)]
    [TestCase(0, 4)]
    [TestCase(-1, 4)]
    public void
        GivenConjuredItemWhichIsPastItsSellByWithQualityFourOrLess_WhenUpdateItemIsCalled_ThenQualityIsDecreasedToZero(int sellIn, int initialQuality)
    {
        // Given
        var item = new Item { Quality = initialQuality, SellIn = sellIn };
        var unitUnderTest = new ConjuredItem(item);

        // When
        unitUnderTest.ProgressItemLifecycle();

        // Then
        Assert.That(item.Quality, Is.EqualTo(0));
    }
}