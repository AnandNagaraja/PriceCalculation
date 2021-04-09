using System.Collections.Generic;

namespace PriceCalculation
{
    public interface IShoppingCart
    {
        double CalculateTotalPriceOfBasket(IEnumerable<string> items);
    }
}