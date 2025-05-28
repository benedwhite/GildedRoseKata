namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    private readonly IList<Item> _items = items ?? throw new ArgumentNullException(nameof(items));

    public void UpdateQuality()
    {
        foreach (Item item in _items)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    UpdateAgedBrie(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstagePass(item);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    continue;
                default:
                    UpdateOtherItem(item);
                    break;
            }
        }
    }

    private static void UpdateAgedBrie(Item item)
    {
        new AgedBrieUpdater(item).Update();
    }

    private static void UpdateBackstagePass(Item item)
    {
        new BackstagePassUpdater(item).Update();
    }

    private static void UpdateOtherItem(Item item)
    {
        new OtherItemUpdater(item).Update();
    }
}
