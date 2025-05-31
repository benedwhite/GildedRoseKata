namespace GildedRoseKata.Validators;

public class ItemQualityValidator(int quality) : IItemValidator
{
    public bool IsValid() => quality >= 0 && quality <= Constants.MaxQuality;
}