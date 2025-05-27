using GildedRoseKata;

namespace GildedRoseTests;

/// <summary>
/// Acceptance tests for the Gilded Rose Kata.
/// </summary>
public class GildedRoseTest
{
    /// <summary>
    /// At the end of each day our system lowers both values for every item
    /// </summary>
    [Fact]
    public void UpdateQuality_ShouldDecreaseSellInAndQualityByOne_GivenNormalItem()
    {
        // Given the item has a sell in value of 10 and a quality value of 20
        Item item = CreateItem("Test Item", 10, quality: 20);
        GildedRose sut = CreateGuildedRose(item);
        int expectedSellIn = 9;
        int expectedQuality = 19;

        // When UpdateQuality is invoked
        sut.UpdateQuality();

        // Then the sell in value should be 9 and the quality value should be 19
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    /// <summary>
    /// Once the sell by date has passed, Quality degrades twice as fast
    /// </summary>
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void UpdateQuality_ShouldDecreaseQualityByTwo_GivenAnItemWithZeroOrNegativeSellIn(int sellIn)
    {
        // Given the item sell by date has passed (0 or negative)
        Item item = CreateItem("Test Item", sellIn, quality: 20);
        GildedRose sut = CreateGuildedRose(item);
        int expectedQuality = 18;

        // When UpdateQuality is invoked
        sut.UpdateQuality();

        // Then the quality degrades twice as fast
        Assert.Equal(expectedQuality, item.Quality);
    }

    private static Item CreateItem(string name, int sellIn, int quality)
        => new() { Name = name, SellIn = sellIn, Quality = quality };

    private static GildedRose CreateGuildedRose(Item item) => new([item]);
}
