namespace GildedRoseKata;

public class AgedBrieUpdater(Item item)
{
    public void Update()
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
}
