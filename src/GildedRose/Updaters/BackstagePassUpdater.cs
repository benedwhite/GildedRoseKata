using GildedRoseKata.Validators;

namespace GildedRoseKata.Updaters;

public class BackstagePassUpdater(Item item, IItemValidator itemValidator) : IItemUpdater
{
    private readonly Item _item = item ?? throw new ArgumentNullException(nameof(item));

    private readonly IItemValidator _itemValidator = itemValidator
        ?? throw new ArgumentNullException(nameof(itemValidator));

    public void Update()
    {
        // Could potentially use someting like template method or
        // decorator pattern to prevent duplication across updaters.
        if (!_itemValidator.IsValid())
        {
            return;
        }

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
