namespace GildedRoseKata;

public class OtherItemUpdater(Item item) : IItemUpdater
{
    public void Update()
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