using System.Collections.Generic;
using kata.Models;

// create array of items
List<Item> items = new List<Item>
{
    new RegularItem("+5 Dexterity Vest", 10, 20),
    new AgedBrie(2, 0),
    new RegularItem("Elixir of the Mongoose", 5, 7),
    new Sulfuras(0, 80),
    new Sulfuras(-1, 80),
    new BackstagePass(15, 20),
    new BackstagePass(10, 49),
    new BackstagePass(5, 49),
    // this conjured item does not work properly yet
    new RegularItem("Conjured Mana Cake", 3, 6)
};

var guildedRose = new GildedRose(items);
guildedRose.UpdateQuality();
