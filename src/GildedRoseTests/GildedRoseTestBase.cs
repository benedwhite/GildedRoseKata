using GildedRoseKata;

namespace GildedRoseTests;

public abstract class GildedRoseTestBase
{
    protected static Item CreateItem(string name, int sellIn, int quality)
        => new() { Name = name, SellIn = sellIn, Quality = quality };
}
