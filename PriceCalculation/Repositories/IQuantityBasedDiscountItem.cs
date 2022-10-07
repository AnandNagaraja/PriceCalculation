using System.Collections.Generic;
using PriceCalculation.Discounts.DTO;

namespace PriceCalculation.Repositories
{
    public interface IQuantityBasedDiscountItem
    {
        List<QuantityBasedDiscountDto> GetQuantityBasedDiscountItem();
    }
}