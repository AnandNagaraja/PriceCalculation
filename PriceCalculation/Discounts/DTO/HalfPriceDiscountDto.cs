using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculation.Discounts.DTO
{
    public class HalfPriceDiscountDto
    {
        public string ItemThatQualifyForDiscount { get; set; }
        public int ItemQuantityThatQualifyForDiscount { get; set; }
        public string ItemOnDiscount { get; set; }
    }
}
