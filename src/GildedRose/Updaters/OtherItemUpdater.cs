using GildedRoseKata.Validators;

namespace GildedRoseKata.Updaters;

public class OtherItemUpdater(Item item, IItemValidator itemValidator) : IItemUpdater
{
    private readonly Item _item = item 
        ?? throw new ArgumentNullException(nameof(item));

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