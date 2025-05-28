namespace GildedRoseKata.Updaters;

public class BackstagePassUpdater(Item item) : IItemUpdater
{
    public void Update()
    {
        if (item.SellIn <= 0)
        {
            item.Quality = 0;
        }
        else
        {
            int qualityIncrease = 1;

            if (item.SellIn <= 10)
            {
                qualityIncrease++;
            }

            if (item.SellIn <= 5)
            {
                qualityIncrease++;
            }

            item.Quality = Math.Min(item.Quality + qualityIncrease, 50);
        }

        item.SellIn--;
    }
}
