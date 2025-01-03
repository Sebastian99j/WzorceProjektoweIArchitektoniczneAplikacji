using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void Foo()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRoseKata.GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Name, Is.EqualTo("foo"));
    }

    [Test]
    public void UpdateQuality_NormalItem_DecreasesQualityByOne()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "Normal Item", SellIn = 10, Quality = 20 } };
        GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(items);

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
        GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(items);

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
        GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(items);

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
        GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(items);

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
        GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(items);

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
        GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(items);

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
        GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(5, Is.EqualTo(items[0].Quality));
        Assert.That(2, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_NormalItem_DecreasesQualityTwiceAsFastAfterSellIn()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "Normal Item", SellIn = 0, Quality = 10 } };
        GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(8, Is.EqualTo(items[0].Quality));
        Assert.That(-1, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_BackstagePasses_DoesNotIncreaseQualityAbove50()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 50 } };
        GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(50, Is.EqualTo(items[0].Quality));
        Assert.That(4, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_ConjuredItem_DecreasesQualityByFourAfterSellIn()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 } };
        GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(6, Is.EqualTo(items[0].Quality));
        Assert.That(-1, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_QualityDoesNotDropBelowZero()
    {
        // Arrange
        IList<Item> items = new List<Item> { new Item { Name = "Normal Item", SellIn = 5, Quality = 0 } };
        GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(0, Is.EqualTo(items[0].Quality));
        Assert.That(4, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_CustomItem_QualityDecreasesByOne()
    {
        //Arrange
        var items = new List<Item> { new Item { Name = "Custom Item", SellIn = 5, Quality = 10 } };
        var app = new GildedRoseKata.GildedRose(items);

        //Act
        app.UpdateQuality();

        //Assert
        Assert.That(9, Is.EqualTo(items[0].Quality));
        Assert.That(4, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_AgedBrie_QualityDoesNotExceed50()
    {
        //Arrange
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 } };
        var app = new GildedRoseKata.GildedRose(items);

        //Act
        app.UpdateQuality();

        //Assert
        Assert.That(50, Is.EqualTo(items[0].Quality));
        Assert.That(4, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_RegularItem_QualityDoesNotGoBelowZero()
    {
        //Arrange
        var items = new List<Item> { new Item { Name = "Regular Item", SellIn = 5, Quality = 0 } };
        var app = new GildedRoseKata.GildedRose(items);

        //Act
        app.UpdateQuality();

        //Assert
        Assert.That(0, Is.EqualTo(items[0].Quality));
        Assert.That(4, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_BackstagePass_QualityDoesNotExceed50()
    {
        //Arrange
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 50 } };
        var app = new GildedRoseKata.GildedRose(items);

        //Act
        app.UpdateQuality();

        //Assert
        Assert.That(50, Is.EqualTo(items[0].Quality));
        Assert.That(4, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_AgedBrie_DoesNotIncreaseQualityAbove50()
    {
        //Arrange
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };
        var app = new GildedRoseKata.GildedRose(items);

        //Act
        app.UpdateQuality();

        //Assert
        Assert.That(50, Is.EqualTo(items[0].Quality));
        Assert.That(-1, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_RegularItem_DoesNotDecreaseQualityBelowZero()
    {
        //Arrange
        var items = new List<Item> { new Item { Name = "Regular Item", SellIn = -1, Quality = 0 } };
        var app = new GildedRoseKata.GildedRose(items);

        //Act
        app.UpdateQuality();

        //Assert
        Assert.That(0, Is.EqualTo(items[0].Quality));
        Assert.That(-2, Is.EqualTo(items[0].SellIn));
    }

    [Test]
    public void UpdateQuality_BackstagePass_DropsQualityToZeroAfterConcert()
    {
        //Arrange
        var items = new List<Item>
            { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
        var app = new GildedRoseKata.GildedRose(items);

        //Act
        app.UpdateQuality();

        //Assert
        Assert.That(0, Is.EqualTo(items[0].Quality));
        Assert.That(-1, Is.EqualTo(items[0].SellIn));
    }
}