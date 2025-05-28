namespace GildedRoseKata;

public class BackstagePassUpdater(Item item)
{
    public void Update()
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
}
