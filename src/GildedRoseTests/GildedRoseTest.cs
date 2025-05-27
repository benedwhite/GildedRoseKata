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


    /// <summary>
    /// The Quality of an item is never negative
    /// </summary>
    [Theory]
    [InlineData(1)]
    [InlineData(0)]
    public void UpdateQuality_ShouldNotDecreaseQualityToNegative_GivenAnItemWithOneOrZeroQuality(int quality)
    {
        // Given the item has a quality value of 0 or 1
        Item item = CreateItem("Test", sellIn: 10, quality);
        GildedRose sut = CreateGuildedRose(item);
        int expectedQuality = 0;

        // When UpdateQuality is invoked
        sut.UpdateQuality();

        // Then the quality value is never negative
        Assert.Equal(expectedQuality, item.Quality);
    }

    /// <summary>
    /// "Aged Brie" actually increases in Quality the older it gets
    /// </summary>
    [Fact]
    public void UpdateQuality_ShouldIncreaseQualityByOne_GivenAnAgedBrieItem()
    {
        // Given the item is "Aged Brie" with a quality value of 1
        Item item = CreateItem("Aged Brie", sellIn: 10, quality: 1);
        GildedRose sut = CreateGuildedRose(item);
        int expectedQuality = 2;

        // When UpdateQuality is invoked
        sut.UpdateQuality();

        // Then the quality value increases by one
        Assert.Equal(expectedQuality, item.Quality);
    }

    /// <summary>
    /// The Quality of an item is never more than 50
    /// </summary>
    [Theory]
    [InlineData(49)]
    [InlineData(50)]
    public void UpdateQuality_ShouldNotIncreaseQualityToBeyond50_GivenAnItemWithAQualityOf49Or50(int quality)
    {
        // Given the item has a quality value of 49 or 50
        Item item = CreateItem("Aged Brie", sellIn: 10, quality);
        GildedRose sut = CreateGuildedRose(item);
        int expectedQuality = 50;

        // When UpdateQuality is invoked and increases quality
        sut.UpdateQuality();

        // Then the quality value is more than 50
        Assert.Equal(expectedQuality, item.Quality);
    }


    private static Item CreateItem(string name, int sellIn, int quality)
        => new() { Name = name, SellIn = sellIn, Quality = quality };

    private static GildedRose CreateGuildedRose(Item item) => new([item]);
}
