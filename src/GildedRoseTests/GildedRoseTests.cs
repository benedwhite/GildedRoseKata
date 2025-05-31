using GildedRoseKata;

namespace GildedRoseTests;

/// <summary>
/// Acceptance tests for the Gilded Rose Kata.
/// </summary>
public class GildedRoseTests
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

        // Then the quality value is not more than 50
        Assert.Equal(expectedQuality, item.Quality);
    }

    /// <summary>
    /// "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    /// </summary>
    [Fact]
    public void UpdateQuality_ShouldNotIncreaseQuality_GivenAnItemThatIsSulfuras()
    {
        // Given a "Sulfuras" item with a quality value of 80
        Item item = CreateItem("Sulfuras, Hand of Ragnaros", sellIn: 10, quality: 80);
        GildedRose sut = CreateGuildedRose(item);
        int expectedQuality = 80;

        // When UpdateQuality is invoked
        sut.UpdateQuality();

        // Then quality does not change
        Assert.Equal(expectedQuality, item.Quality);
    }

    /// <summary>
    /// "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
    /// Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
    /// Quality drops to 0 after the concert
    /// </summary>
    [Theory]
    [InlineData(100, 20, 21)]
    [InlineData(11, 20, 21)]
    [InlineData(10, 20, 22)]
    [InlineData(6, 20, 22)]
    [InlineData(5, 20, 23)]
    [InlineData(1, 20, 23)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, 0, 0)]
    public void UpdateQuality_ShouldAdjustBackstagePassesQuality_BasedOnSellInValue(
        int sellIn, 
        int quality, 
        int expectedQuality)
    {
        // Given a "Backstage passes" item with a provided sell in value
        Item item = CreateItem(
            "Backstage passes to a TAFKAL80ETC concert",
            sellIn,
            quality);
        GildedRose sut = CreateGuildedRose(item);

        // When UpdateQuality is invoked
        sut.UpdateQuality();

        // Then the quality value increases by the expected amount
        Assert.Equal(expectedQuality, item.Quality);
    }

    /// <summary>
    /// "Conjured" items degrade in Quality twice as fast as normal items
    /// </summary>
    [Theory]
    [InlineData(10, 20, 19)]
    [InlineData(1, 20, 19)]
    [InlineData(0, 20, 18)]
    [InlineData(-1, 20, 18)]
    [InlineData(-10, 20, 18)]
    public void UpdateQuality_ShouldDecreaseQualityTwiceAsFast_ForConjuredItems(
        int sellIn,
        int quality,
        int expectedQuality)
    {
        // Given a "Conjured" item with a provided sell in and quality value
        Item item = CreateItem("Conjured Item", sellIn, quality);
        GildedRose sut = CreateGuildedRose(item);

        // When UpdateQuality is invoked
        sut.UpdateQuality();

        // Then the quality value decreases twice as fast when sell in is 0 or negative
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenItemIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new GildedRose(null));
    }

    private static Item CreateItem(string name, int sellIn, int quality)
        => new() { Name = name, SellIn = sellIn, Quality = quality };

    private static GildedRose CreateGuildedRose(Item item) => new([item]);
}
