using GildedRoseKata;
using System.Reflection;

namespace GildedRoseTests;

public class GildedRoseTest
{
    /// <summary>
    /// All items have a SellIn value which denotes the number of days we have to sell the items
    /// All items have a Quality value which denotes how valuable the item is
    /// </summary>
    [Theory]
    [InlineData("SellIn")]
    [InlineData("Quality")]
    public void Item_ShouldHaveSellInProperty(string propName)
    {
        // Act
        PropertyInfo propInfo = typeof(Item)
            .GetProperty(propName);

        // Assert
        Assert.NotNull(propInfo);
    }
}
