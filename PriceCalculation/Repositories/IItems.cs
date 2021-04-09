namespace PriceCalculation.Repositories
{
    public interface IItems
    {
        double GetItemPriceByName(string itemName);
    }
}