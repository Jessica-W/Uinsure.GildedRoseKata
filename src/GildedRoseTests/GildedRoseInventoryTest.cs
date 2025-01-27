using System.Collections.Generic;
using GildedRose;
using NUnit.Framework;

namespace GildedRoseTests
{
    public class GildedRoseInventoryTest
    {
        private const string StandardItemName = "Elixir of the Mongoose";
        private const string AgedItemName = "Aged Brie";
        private const string LegendaryItemName = "Sulfuras, Hand of Ragnaros";
        private const string BackstagePassItemName = "Backstage passes to a TAFKAL80ETC concert";
        private const string ConjuredItemName = "Conjured Mana Cake";

        private GildedRoseInventory CreateUnitUnderTest(Item item) => new GildedRoseInventory(new UpdateableItemFactory(), new List<Item> { item });

        [TestCase(1, StandardItemName)]
        [TestCase(1, AgedItemName)]
        [TestCase(1, BackstagePassItemName)]
        [TestCase(0, StandardItemName)]
        [TestCase(0, AgedItemName)]
        [TestCase(0, BackstagePassItemName)]
        public void GivenNonLegendaryItem_WhenUpdateItemIsCalled_ThenSellInIsDecreasedByOne(int initialSellIn, string itemName)
        {
            // Given
            var item = new Item { Quality = 5, SellIn = initialSellIn, Name = itemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.SellIn, Is.EqualTo(initialSellIn - 1));
        }

        #region StandardItems

        [Test]
        public void
            GivenStandardItemWhichIsNotPastItsSellByWithQualityGreaterThanZero_WhenUpdateItemIsCalled_ThenQualityIsDecreasedByOne()
        {
            // Given
            var item = new Item { Quality = 5, SellIn = 1, Name = StandardItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(4));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void
            GivenStandardItemWhichIsPastItsSellByWithQualityGreaterThanOne_WhenUpdateItemIsCalled_ThenQualityIsDecreasedByTwo(int sellIn)
        {
            // Given
            var item = new Item { Quality = 5, SellIn = sellIn, Name = StandardItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(3));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void
            GivenStandardItemWhichIsPastItsSellByWithQualityOfOne_WhenUpdateItemIsCalled_ThenQualityIsDecreasedToZero(int sellIn)
        {
            // Given
            var item = new Item { Quality = 1, SellIn = sellIn, Name = StandardItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(0));
        }

        #endregion Standard Items

        #region Aged Items

        [TestCase(1)]
        [TestCase(0)]
        public void GivenAgedItem_WhenUpdateItemIsCalled_ThenSellInIsDecreasedByOne(int initialSellIn)
        {
            // Given
            var item = new Item { SellIn = initialSellIn, Name = AgedItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.SellIn, Is.EqualTo(initialSellIn - 1));
        }

        [Test]
        public void
            GivenAgedItemWhichIsNotPastItsSellByWithQualityGreaterThanZero_WhenUpdateItemIsCalled_ThenQualityIsIncreasedByOne()
        {
            // Given
            var item = new Item { Quality = 5, SellIn = 1, Name = AgedItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(6));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void
            GivenAgedItemWhichIsNotPastItsSellByWithQualityGreaterThanOne_WhenUpdateItemIsCalled_ThenQualityIsIncreasedByTwo(int sellIn)
        {
            // Given
            var item = new Item { Quality = 5, SellIn = sellIn, Name = AgedItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(7));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void
            GivenAgedItemWhichIsNotPastItsSellByWithQualityOfFortyNine_WhenUpdateItemIsCalled_ThenQualityIsIncreasedToFifty(int sellIn)
        {
            // Given
            var item = new Item { Quality = 49, SellIn = sellIn, Name = AgedItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(50));
        }

        #endregion AgedBrie

        #region Backstage Pass

        [Test]
        public void GivenBackstagePassItem_WhenUpdateItemIsCalled_ThenSellInIsDecreasedByOne()
        {
            // Given
            var item = new Item { SellIn = 99, Name = BackstagePassItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.SellIn, Is.EqualTo(98));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void GivenBackstagePassItemWithSellInOfZeroOrLess_WhenUpdateItemIsCalled_ThenQualityReducedToZero(int sellIn)
        {
            // Given
            var item = new Item { Quality = 30, SellIn = sellIn, Name = BackstagePassItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [TestCase(5)]
        [TestCase(4)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        public void
            GivenBackstagePassItemWithSellInOfFiveOrLessAndQualityWouldNotExceedFifty_WhenUpdateItemIsCalled_ThenQualityIsIncreasedByThree(int sellIn)
        {
            // Given
            var item = new Item { Quality = 30, SellIn = sellIn, Name = BackstagePassItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(33));
        }

        [TestCase(48)]
        [TestCase(49)]
        [TestCase(50)]
        public void
            GivenBackstagePassItemWithSellInOfFiveOrLessAndQualityWouldExceedFifty_WhenUpdateItemIsCalled_ThenQualityIsIncreasedToFifty(int quality)
        {
            // Given
            var item = new Item { Quality = quality, SellIn = 5, Name = BackstagePassItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(50));
        }

        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        public void
            GivenBackstagePassItemWithSellInBetweenSixAndTenAndQualityWouldNotExceedFifty_WhenUpdateItemIsCalled_ThenQualityIsIncreasedByTwo(int sellIn)
        {
            // Given
            var item = new Item { Quality = 30, SellIn = sellIn, Name = BackstagePassItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(32));
        }

        [TestCase(49)]
        [TestCase(50)]
        public void
            GivenBackstagePassItemWithSellInBetweenSixAndTenAndQualityWouldExceedFifty_WhenUpdateItemIsCalled_ThenQualityIsIncreasedToFifty(int quality)
        {
            // Given
            var item = new Item { Quality = quality, SellIn = 10, Name = BackstagePassItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(50));
        }

        [TestCase(48, 49)]
        [TestCase(49, 50)]
        [TestCase(50, 50)]
        public void
            GivenBackstagePassItemWithSellInGreaterThanTen_WhenUpdateItemIsCalled_ThenQualityIsIncreasedTByOneButCappedAtFifty(int quality, int expectedUpdatedQuality)
        {
            // Given
            var item = new Item { Quality = quality, SellIn = 11, Name = BackstagePassItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(expectedUpdatedQuality));
        }

        #endregion BackstagePass

        #region Legendary Items

        [Test]
        public void GivenLegendaryItem_WhenUpdateItemIsCalled_ThenSellInIsUnchangedAndQualityIsEighty()
        {
            // Given
            var item = new Item { Quality = 60, SellIn = 10, Name = LegendaryItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.SellIn, Is.EqualTo(10));
            Assert.That(item.Quality, Is.EqualTo(80));
        }

        #endregion
        
        #region Conjured Items

        [Test]
        public void
            GivenConjuredItemWhichIsNotPastItsSellByWithQualityGreaterThanOne_WhenUpdateItemIsCalled_ThenQualityIsDecreasedByTwo()
        {
            // Given
            var item = new Item { Quality = 3, SellIn = 1, Name = ConjuredItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(1));
        }
        
        [Test]
        public void
            GivenConjuredItemWhichIsNotPastItsSellByWithQualityOfOne_WhenUpdateItemIsCalled_ThenQualityIsDecreasedToZero()
        {
            // Given
            var item = new Item { Quality = 1, SellIn = 1, Name = ConjuredItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(0));
        }
        
        [TestCase(0)]
        [TestCase(-1)]
        public void
            GivenConjuredItemWhichIsPastItsSellByWithQualityGreaterThanThree_WhenUpdateItemIsCalled_ThenQualityIsDecreasedByFour(int sellIn)
        {
            // Given
            var item = new Item { Quality = 5, SellIn = sellIn, Name = ConjuredItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

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
            var item = new Item { Quality = initialQuality, SellIn = sellIn, Name = ConjuredItemName };
            var unitUnderTest = CreateUnitUnderTest(item);

            // When
            unitUnderTest.UpdateItem();

            // Then
            Assert.That(item.Quality, Is.EqualTo(0));
        }

        #endregion Conjured Items
    }
}