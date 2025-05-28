namespace GildedRoseKata.Updaters;

public class BackstagePassUpdater(Item item) : IItemUpdater
{
    private readonly Item _item = item ?? throw new ArgumentNullException(nameof(item));

    public void Update()
    {
        if (_item.SellIn <= 0)
        {
            _item.Quality = 0;
        }
        else if (item.Quality < 50)
        {
            _item.Quality++;

            if (_item.SellIn <= 10 && _item.Quality < 50)
            {
                _item.Quality++;
            }

            if (_item.SellIn <= 5 && _item.Quality < 50)
            {
                _item.Quality++;
            }
        }

        _item.SellIn--;
    }
}
