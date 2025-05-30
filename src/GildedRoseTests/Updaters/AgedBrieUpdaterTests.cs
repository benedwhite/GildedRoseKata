﻿using GildedRoseKata;
using GildedRoseKata.Updaters;
using GildedRoseKata.Validators;

namespace GildedRoseTests.Updaters;

public class AgedBrieUpdaterTests : GildedRoseTestBase
{
    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenItemIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new AgedBrieUpdater(
            null, new ItemQualityValidator(1)));
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenItemValidatorIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new AgedBrieUpdater(
            CreateItem("Test Item", 1, 1), null));
    }

    [Fact]
    public void Update_ShouldDecreaseSellIn_WhenCalled()
    {
        // Arrange
        Item item = CreateItem(Constants.Items.AgedBrie, sellIn: 20, quality: 20);
        AgedBrieUpdater updater = CreateAgedBrieUpdater(item);

        // Act
        updater.Update();

        // Assert
        Assert.Equal(19, item.SellIn);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(49, 50)]
    [InlineData(50, 50)]
    public void Update_ShouldIncreaseQualityByOne_GivenAnItemWithQualityLessThan50AndSellInGreaterThanZero(
        int quality,
        int expectedQuality)
    {
        // Arrange
        Item item = CreateItem(Constants.Items.AgedBrie, sellIn: 1, quality);
        AgedBrieUpdater updater = CreateAgedBrieUpdater(item);

        // Act
        updater.Update();

        // Assert
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Theory]
    [InlineData(1, 3)]
    [InlineData(48, 50)]
    [InlineData(49, 50)]
    [InlineData(50, 50)]
    public void Update_ShouldIncreaseQualityByTwoToNoMoreThan50_GivenAnItemWithQualityLessThan50AndSellInLessThanOrEqualToZero(
        int quality,
        int expectedQuality)
    {
        // Arrange
        Item item = CreateItem(Constants.Items.AgedBrie, sellIn: 0, quality);
        AgedBrieUpdater updater = CreateAgedBrieUpdater(item);

        // Act
        updater.Update();

        // Assert
        Assert.Equal(expectedQuality, item.Quality);
    }

    private static AgedBrieUpdater CreateAgedBrieUpdater(Item item) => new(
        item, 
        new ItemQualityValidator(item.Quality));
}
