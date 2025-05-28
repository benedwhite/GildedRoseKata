namespace GildedRoseKata;

public class BackstagePassUpdater(Item item) : IItemUpdater
{
    public void Update()
    {
        if (item.Quality < 50)
        {
            item.Quality++;
        }

        if (item.SellIn < 11 && item.Quality < 50)
        {
            item.Quality++;
        }

        if (item.SellIn < 6 && item.Quality < 50)
        {
            item.Quality++;
        }

        if (item.SellIn <= 0)
        {
            item.Quality -= item.Quality;
        }

        item.SellIn--;
    }
}
