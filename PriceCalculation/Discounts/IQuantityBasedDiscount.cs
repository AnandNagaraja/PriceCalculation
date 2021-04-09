using System.Collections.Generic;

namespace PriceCalculation.Discounts
{
    public interface IQuantityBasedDiscount
    {
        double ApplyAndGetQuantityBasedDiscount(Dictionary<string, int> basketItemQuantity);
    }
}