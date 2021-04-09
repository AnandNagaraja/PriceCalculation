using System;
using System.Collections.Generic;
using System.Text;
using PriceCalculation.Discounts.DTO;

namespace PriceCalculation.Repositories
{
    public class HalfPriceDiscountItem : IHalfPriceDiscountItem
    {
        // Todo: this should return collection of HalfPriceDiscountDto, as there will be multiple items on offer
        public HalfPriceDiscountDto GetHalfPriceDiscountItem()
        {
            return new HalfPriceDiscountDto()
            {
                ItemOnDiscount = "Bread",
                ItemQuantityThatQualifyForDiscount = 2,
                ItemThatQualifyForDiscount = "Butter"
            };
        }
    }
}
