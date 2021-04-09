using System;
using System.Collections.Generic;
using System.Text;
using PriceCalculation.Discounts.DTO;

namespace PriceCalculation.Repositories
{
    public class QuantityBasedDiscountItem : IQuantityBasedDiscountItem
    {

        // Todo: this should return collection of QuantityBasedDiscountDto, as there will be multiple items on offer
        public QuantityBasedDiscountDto GetQuantityBasedDiscountItem()
        {
            return new QuantityBasedDiscountDto()
            {
                ItemOnOffer = "Milk",
                ItemQuantityOnOffer = 3
            };
        }

    }
}
