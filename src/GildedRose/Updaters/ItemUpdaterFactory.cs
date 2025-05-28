namespace GildedRoseKata.Updaters;

public static class ItemUpdaterFactory
{
    public static IItemUpdater Create(Item item)
        => item.Name switch
        {
            "Aged Brie" => new AgedBrieUpdater(item),
            "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassUpdater(item),
            "Sulfuras, Hand of Ragnaros" => new SulfurasUpdater(),
            "Conjured Mana Cake" => new ConjuredItemUpdater(item),
            _ => new OtherItemUpdater(item)
        };
}
