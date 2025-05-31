namespace GildedRoseKata.Updaters;

public class ConjuredItemUpdater(Item item) : IItemUpdater
{
    private readonly Item _item = item ?? throw new ArgumentNullException(nameof(item));

    public void Update()
    {
        _item.SellIn--;

        int degradation = _item.SellIn < 0 ? 2 : 1;
        int qualityAfterDegradation = _item.Quality - degradation;
        int finalQuality = _item.Quality - qualityAfterDegradation < Constants.MaxQuality 
            ? qualityAfterDegradation 
            : Constants.MaxQuality;

        _item.Quality = Math.Max(0, finalQuality);
    }
}