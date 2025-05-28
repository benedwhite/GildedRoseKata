namespace GildedRoseKata.Updaters;

public class OtherItemUpdater(Item item) : IItemUpdater
{
    public void Update()
    {
        if (item.Quality > 0)
        {
            item.Quality--;
        }

        item.SellIn--;

        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality--;
        }
    }
}