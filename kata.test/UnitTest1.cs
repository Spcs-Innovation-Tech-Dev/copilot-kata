using kata;
using Xunit;
using kata.Models;

public class UnitTest1
{
    [Fact]
    public void Ensure_Quality()
    {
        var items = new AgedBrie[] { new AgedBrie(4, 1) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();

        // print out the item name and quality
        Console.WriteLine(items[0].Name + " " + items[0].Quality);

        Assert.Equal(2, items[0].Quality);
    }

    [Fact]
    public void Sulfuras_Never_Decreases_Quality()
    {
        var items = new Sulfuras[] { new Sulfuras(0, 80) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();
        Assert.Equal(80, items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_Increases_Quality_As_SellIn_Approaches()
    {
        var items = new BackstagePass[] { new BackstagePass(15, 20) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();
        Assert.Equal(21, items[0].Quality);
    }

    [Fact]
    public void NormalItem_Decreases_Quality_Over_Time()
    {
        var items = new RegularItem[] { new RegularItem("Elixir of the Mongoose", 10, 20) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();
        Assert.Equal(19, items[0].Quality);
    }
    [Fact]
    public void AgedBrie_Increases_Quality_Twice_As_Fast_After_SellIn()
    {
        var items = new AgedBrie[] { new AgedBrie(0, 0) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();
        Assert.Equal(2, items[0].Quality);
    }

    [Fact]
    public void NormalItem_Decreases_Quality_Twice_As_Fast_After_SellIn()
    {
        var items = new RegularItem[] { new RegularItem("+5 Dexterity Vest", 0, 20) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();
        Assert.Equal(18, items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_Quality_Drops_To_Zero_After_SellIn()
    {
        var items = new BackstagePass[] { new BackstagePass(0, 20) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void Sulfuras_Quality_Remains_Constant_After_SellIn()
    {
        var items = new Sulfuras[] { new Sulfuras(0, 80) };
        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();
        Assert.Equal(80, items[0].Quality);
    }

    [Fact]
    public void Item_ToString_ReturnsCorrectFormat()
    {
        var item = new RegularItem("Test Item", 10, 20);
        var result = item.ToString();
        Assert.Equal("Test Item, 10, 20", result);
    }

    // [Fact]
    // public void ConjuredItem_Decreases_Quality_Twice_As_Fast_After_SellIn()
    // {
    //     var items = new Item[] { new Item("Conjured Mana Cake", 0, 6) };
    //     var gildedRose = new GildedRose(items);
    //     gildedRose.UpdateQuality();
    //     Assert.Equal(2, items[0].Quality);
    // }
}