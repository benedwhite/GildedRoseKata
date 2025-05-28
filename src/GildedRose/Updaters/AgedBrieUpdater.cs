using GildedRoseKata;

namespace GildedRose.Updaters;

public class AgedBrieUpdater(Item item) : IItemUpdater
{
    public void Update()
    {
        if (item.SellIn <= 0 && item.Quality < 50)
        {
            item.Quality++;
        }

        if (item.Quality < 50)
        {
            item.Quality++;
        }

        item.SellIn--;
    }
}
