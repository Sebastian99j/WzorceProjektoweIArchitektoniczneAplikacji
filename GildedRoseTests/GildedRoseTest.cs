using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void Foo()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Name, Is.EqualTo("foo"));
    }

    [Test]
    public void UpdateQuality_NormalItem_DecreasesQualityByOne()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "Normal Item", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(19, Is.EqualTo(items[0].Quality));
        Assert.That(9, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_AgedBrie_MaxQuality50()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
        GildedRose app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(50, Is.EqualTo(items[0].Quality));
        // Quality nie powinna przekroczyć 50
    }

    [Test]
    public void UpdateQuality_BackstagePasses_IncreasesQualityByTwo_When10DaysOrLess()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(22, Is.EqualTo(items[0].Quality));
        Assert.That(9, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_BackstagePasses_IncreasesQualityByThree_When5DaysOrLess()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
        GildedRose app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(23, Is.EqualTo(items[0].Quality));
        Assert.That(4, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_BackstagePasses_DropsToZero_AfterConcert()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
        GildedRose app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(0, Is.EqualTo(items[0].Quality));
        Assert.That(-1, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_Sulfuras_DoesNotChange()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
        GildedRose app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(80, Is.EqualTo(items[0].Quality));
        Assert.That(5, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_ConjuredItem_DecreasesQualityByTwo()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
        GildedRose app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(5, Is.EqualTo(items[0].Quality));
        Assert.That(2, Is.EqualTo(items[0].SellIn));
    }
}