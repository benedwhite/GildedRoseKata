using GildedRoseKata.Validators;

namespace GildedRoseKata.Updaters;

public static class ItemUpdaterFactory
{
    public static IItemUpdater Create(Item item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));

        ItemQualityValidator itemQualityValidator = new(item.Quality);

        return item.Name switch
        {
            Constants.Items.AgedBrie => new AgedBrieUpdater(item, itemQualityValidator),
            Constants.Items.BackstagePass => new BackstagePassUpdater(item, itemQualityValidator),
            Constants.Items.Sulfuras => new SulfurasUpdater(),
            Constants.Items.Conjured => new ConjuredItemUpdater(item, itemQualityValidator),
            _ => new OtherItemUpdater(item, itemQualityValidator)
        };
    }
}
