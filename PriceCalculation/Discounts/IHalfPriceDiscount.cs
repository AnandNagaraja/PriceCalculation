using System.Collections.Generic;

namespace PriceCalculation.Discounts
{
    public interface IHalfPriceDiscount
    {
        double ApplyAndGetHalfPriceDiscount(Dictionary<string, int> basketItemQuantity);
    }
}