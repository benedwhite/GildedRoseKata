namespace GildedRoseKata.Updaters;

public class BackstagePassUpdater(Item item) : IItemUpdater
{
    public void Update()
    {
        if (item.SellIn <= 0)
        {
            item.Quality = 0;
        }
        else if (item.Quality < 50)
        {
            item.Quality++;

            if (item.SellIn <= 10 && item.Quality < 50)
            {
                item.Quality++;
            }

            if (item.SellIn <= 5 && item.Quality < 50)
            {
                item.Quality++;
            }
        }

        item.SellIn--;
    }
}
