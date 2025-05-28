namespace GildedRoseKata.Updaters;

public class ConjuredItemUpdater(Item item) : IItemUpdater
{
    public void Update()
    {
        item.SellIn--;

        int degradation = item.SellIn < 0 ? 2 : 1;

        item.Quality = Math.Max(0, item.Quality - degradation);
    }
}