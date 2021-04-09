using PriceCalculation.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculation.Discounts
{
    public class QuantityBasedDiscount : IQuantityBasedDiscount
    {
        private readonly QuantityBasedDiscountItem _quantityBasedDiscountItem;
        private readonly Items _items;

        public QuantityBasedDiscount(QuantityBasedDiscountItem quantityBasedDiscountItem, Items items)
        {
            _quantityBasedDiscountItem = quantityBasedDiscountItem;
            _items = items;
        }


        public double ApplyAndGetQuantityBasedDiscount(Dictionary<string, int> basketItemQuantity)
        {
            var quantityBasedDiscountItem = _quantityBasedDiscountItem.GetQuantityBasedDiscountItem();
            foreach (var basketItem in basketItemQuantity)
            {
                if (basketItem.Key == quantityBasedDiscountItem.ItemOnOffer &&
                    basketItem.Value > quantityBasedDiscountItem.ItemQuantityOnOffer)
                {
                    var itemRemainingForOffer = basketItem.Value % quantityBasedDiscountItem.ItemQuantityOnOffer;
                    var offerMultiplier = Convert.ToInt32((basketItem.Value) / quantityBasedDiscountItem.ItemQuantityOnOffer);

                    if (itemRemainingForOffer < offerMultiplier)
                    {
                        offerMultiplier -= 1;
                    }

                    return Math.Round(_items.GetItemPriceByName(quantityBasedDiscountItem.ItemOnOffer) * offerMultiplier, 2);

                }
            }

            return 0;
        }
    }
}
