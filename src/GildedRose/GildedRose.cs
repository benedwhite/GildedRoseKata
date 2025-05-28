using GildedRose.Updaters;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    private readonly IList<Item> _items = items ?? throw new ArgumentNullException(nameof(items));

    public void UpdateQuality()
    {
        foreach (Item item in _items)
        {
            ItemUpdaterFactory.Create(item).Update();
        }
    }
}
