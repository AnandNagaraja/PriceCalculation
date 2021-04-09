using PriceCalculation.Discounts.DTO;

namespace PriceCalculation.Repositories
{
    public interface IQuantityBasedDiscountItem
    {
        QuantityBasedDiscountDto GetQuantityBasedDiscountItem();
    }
}