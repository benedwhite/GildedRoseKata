namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    private readonly IList<Item> _items = items ?? throw new ArgumentNullException(nameof(items));

    public void UpdateQuality()
    {
        foreach (Item item in _items)
        {
            if (item.Name != "Aged Brie"
                && item.Name != "Backstage passes to a TAFKAL80ETC concert"
                && item.Name != "Sulfuras, Hand of Ragnaros"
                && item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }

            if ((item.Name == "Aged Brie"
                || item.Name == "Backstage passes to a TAFKAL80ETC concert")
                && item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            if ((item.Name == "Aged Brie"
                || item.Name == "Backstage passes to a TAFKAL80ETC concert")
                && item.Name == "Backstage passes to a TAFKAL80ETC concert"
                && item.SellIn < 11
                && item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            if ((item.Name == "Aged Brie"
                || item.Name == "Backstage passes to a TAFKAL80ETC concert")
                && item.Name == "Backstage passes to a TAFKAL80ETC concert"
                && item.SellIn < 6
                && item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0
                && item.Name != "Aged Brie"
                && item.Name != "Backstage passes to a TAFKAL80ETC concert"
                && item.Name != "Sulfuras, Hand of Ragnaros"
                && item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }

            if (item.SellIn < 0
                && item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = item.Quality - item.Quality;
            }

            if (item.SellIn < 0
                && item.Quality < 50
                && item.Name == "Aged Brie")
            {
                item.Quality = item.Quality + 1;
            }
        }
    }
}
