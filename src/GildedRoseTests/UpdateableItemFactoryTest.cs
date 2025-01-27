using GildedRose;
using GildedRose.Items;
using NUnit.Framework;

namespace GildedRoseTests;

public class UpdateableItemFactoryTest
{
    [Test]
    public void GivenItemWithAgedItemName_WhenUpdateableItemFromItemIsCalled_ThenAgedItemObjectIsReturned()
    {
        // Given
        var item = new Item { Name = "Aged Brie" };
        var unitUnderTest = new UpdateableItemFactory();

        // When
        var result = unitUnderTest.UpdateableItemFromItem(item);

        // Then
        Assert.That(result, Is.InstanceOf<AgedItem>());
    }
    
    [Test]
    public void GivenItemWithLegendaryItemName_WhenUpdateableItemFromItemIsCalled_ThenLegendaryItemObjectIsReturned()
    {
        // Given
        var item = new Item { Name = "Sulfuras, Hand of Ragnaros" };
        var unitUnderTest = new UpdateableItemFactory();

        // When
        var result = unitUnderTest.UpdateableItemFromItem(item);

        // Then
        Assert.That(result, Is.InstanceOf<LegendaryItem>());
    }
    
    [Test]
    public void GivenItemWithConjuredItemName_WhenUpdateableItemFromItemIsCalled_ThenConjuredItemObjectIsReturned()
    {
        // Given
        var item = new Item { Name = "Conjured Mana Cake" };
        var unitUnderTest = new UpdateableItemFactory();

        // When
        var result = unitUnderTest.UpdateableItemFromItem(item);

        // Then
        Assert.That(result, Is.InstanceOf<ConjuredItem>());
    }
    
    [Test]
    public void GivenItemWithBackstagePassItemName_WhenUpdateableItemFromItemIsCalled_ThenBackstagePassObjectIsReturned()
    {
        // Given
        var item = new Item { Name = "Backstage passes " };
        var unitUnderTest = new UpdateableItemFactory();

        // When
        var result = unitUnderTest.UpdateableItemFromItem(item);

        // Then
        Assert.That(result, Is.InstanceOf<BackstagePass>());
    }
    
    [Test]
    public void GivenItemWithStandardItemName_WhenUpdateableItemFromItemIsCalled_ThenStandardItemObjectIsReturned()
    {
        // Given
        var item = new Item { Name = "Axe" };
        var unitUnderTest = new UpdateableItemFactory();

        // When
        var result = unitUnderTest.UpdateableItemFromItem(item);

        // Then
        Assert.That(result, Is.InstanceOf<StandardItem>());
    }
}