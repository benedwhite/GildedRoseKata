namespace GildedRoseKata.Updaters;

public class ConjuredItemUpdater(Item item) : IItemUpdater
{
    private readonly Item _item = item ?? throw new ArgumentNullException(nameof(item));

    public void Update()
    {
        _item.SellIn--;

        int degradation = _item.SellIn < 0 ? 2 : 1;

        _item.Quality = Math.Max(0, _item.Quality - degradation);
    }
}