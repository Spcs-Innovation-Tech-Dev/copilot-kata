using kata;
using Xunit;
using kata.Models;

public class UnitTest1
{
    [Fact]
    public void Ensure_Quality()
    {
        var items = new Item[] { new Item("brie", 4, 1) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();
        
        // print out the item name and quality
        Console.WriteLine(items[0].Name + " " + items[0].Quality);

        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void Ensure_Sellin()
    {
        var items = new Item[] { new Item("brie", 4, 1) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();
        
        // print out the item name and quality
        Console.WriteLine(items[0].Name + " " + items[0].Quality);

        Assert.Equal(3, items[0].SellIn);
    }

    [Fact]
    public void UpdateQuality_WhenSellInLessThanZero_UpdatesQualityCorrectly()
    {
        // Arrange
        var items = new List<Item>
    {
        new Item("Aged Brie", -1, 20),
        new Item("Backstage passes to a TAFKAL80ETC concert", -1, 20),
        new Item("Sulfuras, Hand of Ragnaros", -1, 20),
        new Item("Regular Item", -1, 20)
    };
        var gildedRose = new GildedRose(items);

        // Act
        gildedRose.UpdateQuality();

        // Assert
        Assert.Equal(22, items[0].Quality); // Aged Brie increases in Quality
        Assert.Equal(0, items[1].Quality); // Backstage passes drops to 0 after the concert
        Assert.Equal(20, items[2].Quality); // Sulfuras, Hand of Ragnaros never decreases in Quality
        Assert.Equal(18, items[3].Quality); // Regular Item decreases by 2 in Quality
    }

    [Fact]
    public void Ensure_Quality_Of_Sulfuras()
    {
        var items = new Item[] { new Item("Sulfuras, Hand of Ragnaros", 4, 80) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();

        Assert.Equal(80, items[0].Quality);
        Assert.Equal(4, items[0].SellIn);
    }

    [Fact]
    public void Ensure_Quality_Of_Backstage_Passes()
    {
        var items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 15, 20) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();

        Assert.Equal(21, items[0].Quality);
        Assert.Equal(14, items[0].SellIn);
    }

    [Fact]
    public void Ensure_Quality_Of_Backstage_Passes_When_SellIn_Less_Than_10()
    {
        var items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 9, 20) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();

        Assert.Equal(22, items[0].Quality);
        Assert.Equal(8, items[0].SellIn);
    }

    [Fact]
    public void Ensure_Quality_Of_Backstage_Passes_When_SellIn_Less_Than_5()
    {
        var items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 4, 20) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();

        Assert.Equal(23, items[0].Quality);
        Assert.Equal(3, items[0].SellIn);
    }

    [Fact]
    public void Ensure_Quality_Of_Backstage_Passes_After_Concert()
    {
        var items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 0, 20) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();

        Assert.Equal(0, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }

 [Fact]
    public void Ensure_Quality_Of_Aged_Brie()
    {
        var items = new Item[] { new Item("Aged Brie", 4, 1) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();

        Assert.Equal(2, items[0].Quality);
        Assert.Equal(3, items[0].SellIn);
    }

    [Fact]
    public void Ensure_Quality_Of_Aged_Brie_After_SellIn()
    {
        var items = new Item[] { new Item("Aged Brie", 0, 1) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();

        Assert.Equal(3, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }

    [Fact]
    public void Ensure_Quality_Of_Aged_Brie_At_Max_Quality()
    {
        var items = new Item[] { new Item("Aged Brie", 4, 50) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();

        Assert.Equal(50, items[0].Quality);
        Assert.Equal(3, items[0].SellIn);
    }
}