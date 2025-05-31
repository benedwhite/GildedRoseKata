namespace GildedRoseKata.Updaters;

public class OtherItemUpdater(Item item) : IItemUpdater
{
    private readonly Item _item = item ?? throw new ArgumentNullException(nameof(item));

    public void Update()
    {
        if (_item.Quality > 0)
        {
            _item.Quality--;
        }

        _item.SellIn--;

        if (_item.SellIn < 0 && _item.Quality > 0)
        {
            _item.Quality--;
        }
    }
}