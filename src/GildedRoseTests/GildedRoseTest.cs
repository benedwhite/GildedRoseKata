using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    /// <summary>
    /// At the end of each day our system lowers both values for every item
    /// </summary>
    [Fact]
    public void UpdateQuality_DecreasesSellInAndQualityByOne_ForNormalItem()
    {
        // Given the item has a sell in value of 10 and a quality value of 20
        Item item = new()
        {
            Name = "Test Item",
            SellIn = 10,
            Quality = 20
        };
        GildedRose sut = new([item]);

        // When UpdateQuality is invoked
        sut.UpdateQuality();

        // Then the sell in value should be 9 and the quality value should be 19
        Assert.Equal(9, item.SellIn);
        Assert.Equal(19, item.Quality);
    }
}
