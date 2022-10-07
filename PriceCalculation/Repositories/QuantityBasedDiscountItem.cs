using System;
using System.Collections.Generic;
using System.Text;
using PriceCalculation.Discounts.DTO;

namespace PriceCalculation.Repositories
{
    public class QuantityBasedDiscountItem : IQuantityBasedDiscountItem
    {

        public List<QuantityBasedDiscountDto> GetQuantityBasedDiscountItem()
        {
            return new List<QuantityBasedDiscountDto>() {
            new QuantityBasedDiscountDto
            {
                ItemOnOffer = "Milk",
                ItemQuantityOnOffer = 3
            },
            new QuantityBasedDiscountDto
            {
                ItemOnOffer = "Bread",
                ItemQuantityOnOffer = 2
            }
            };
        }

    }
}
