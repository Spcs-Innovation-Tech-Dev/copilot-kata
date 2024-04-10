namespace kata.Models;

public abstract class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    protected Item(string name, int sellIn, int quality)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }

    public abstract void UpdateQuality();

    public override string ToString()
    {
        return this.Name + ", " + this.SellIn + ", " + this.Quality;
    }
}

public class AgedBrie : Item
{
    public AgedBrie(int sellIn, int quality) : base("Aged Brie", sellIn, quality) { }

    public override void UpdateQuality()
    {
        if (Quality < 50)
        {
            Quality++;
        }

        SellIn--;

        if (SellIn < 0 && Quality < 50)
        {
            Quality++;
        }
    }
}

public class BackstagePass : Item
{
    public BackstagePass(int sellIn, int quality) : base("Backstage passes to a TAFKAL80ETC concert", sellIn, quality) { }

    public override void UpdateQuality()
    {
        if (Quality < 50)
        {
            Quality++;

            if (SellIn < 11 && Quality < 50)
            {
                Quality++;
            }

            if (SellIn < 6 && Quality < 50)
            {
                Quality++;
            }
        }

        SellIn--;

        if (SellIn < 0)
        {
            Quality = 0;
        }
    }
}

public class Sulfuras : Item
{
    public Sulfuras(int sellIn, int quality) : base("Sulfuras, Hand of Ragnaros", sellIn, quality) { }

    public override void UpdateQuality()
    {
        // Quality of Sulfuras never decreases
    }
}

public class RegularItem : Item
{
    public RegularItem(string name, int sellIn, int quality) : base(name, sellIn, quality) { }

    public override void UpdateQuality()
    {
        if (Quality > 0)
        {
            Quality--;
        }

        SellIn--;

        if (SellIn < 0 && Quality > 0)
        {
            Quality--;
        }
    }
}

public class GildedRose
{
    IList<Item> Items;
    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            item.UpdateQuality();
        }
    }
}
