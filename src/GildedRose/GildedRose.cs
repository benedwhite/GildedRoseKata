namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    private readonly IList<Item> _items = items ?? throw new ArgumentNullException(nameof(items));

    public void UpdateQuality()
    {
        foreach (Item item in _items)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    UpdateAgedBrie(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstagePass(item);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    continue;
                default:
                    UpdateOtherItem(item);
                    break;
            }
        }
    }

    private static void UpdateAgedBrie(Item item)
    {
        if (item.SellIn <= 0 && item.Quality < 50)
        {
            item.Quality = item.Quality + 1;
        }

        if (item.Quality < 50)
        {
            item.Quality = item.Quality + 1;
        }

        item.SellIn = item.SellIn - 1;
    }

    private static void UpdateBackstagePass(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality = item.Quality + 1;
        }

        if (item.SellIn < 11
            && item.Quality < 50)
        {
            item.Quality = item.Quality + 1;
        }

        if (item.SellIn < 6 && item.Quality < 50)
        {
            item.Quality = item.Quality + 1;
        }

        if (item.SellIn <= 0)
        {
            item.Quality = item.Quality - item.Quality;
        }

        item.SellIn = item.SellIn - 1;
    }

    private static void UpdateOtherItem(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality = item.Quality - 1;
        }

        item.SellIn = item.SellIn - 1;

        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality = item.Quality - 1;
        }
    }
}
