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
        else
        {
            int qualityIncrease = 1;

            if (_item.SellIn <= 10)
            {
                qualityIncrease++;
            }

            if (_item.SellIn <= 5)
            {
                qualityIncrease++;
            }

            _item.Quality = Math.Min(
                _item.Quality + qualityIncrease, 
                Constants.MaxQuality);
        }

        _item.SellIn--;
    }
}
