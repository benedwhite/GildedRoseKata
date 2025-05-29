using GildedRoseKata.Updaters;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    public void UpdateQuality()
    {
        foreach (Item item in items)
        {
            ItemUpdaterFactory.Create(item).Update();
        }
    }
}
