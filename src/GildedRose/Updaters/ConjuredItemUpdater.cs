using GildedRoseKata.Validators;

namespace GildedRoseKata.Updaters;

public class ConjuredItemUpdater(Item item, IItemValidator itemValidator) : IItemUpdater
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

        _item.SellIn--;

        int degradation = _item.SellIn < 0 ? 2 : 1;
        int qualityAfterDegradation = _item.Quality - degradation;
        int finalQuality = _item.Quality - qualityAfterDegradation < Constants.MaxQuality
            ? qualityAfterDegradation
            : Constants.MaxQuality;

        _item.Quality = Math.Max(0, finalQuality);
    }
}