using PriceCalculation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var quantityBasedDiscountItems = _quantityBasedDiscountItem.GetQuantityBasedDiscountItem();
            var discountAmount = 0.00;
            foreach (var basketItem in basketItemQuantity)
            {

                var itemQuantityOnOffer = from quantityBasedDiscountItemSelect in quantityBasedDiscountItems
                    where quantityBasedDiscountItemSelect.ItemOnOffer == basketItem.Key
                    select quantityBasedDiscountItemSelect;

                var itemQuantityOnOfferList = itemQuantityOnOffer.ToList();

                if (!itemQuantityOnOfferList.Any() || basketItem.Value <= itemQuantityOnOfferList.FirstOrDefault()!.ItemQuantityOnOffer) continue;

                var itemRemainingForOffer = basketItem.Value % itemQuantityOnOfferList.FirstOrDefault()!.ItemQuantityOnOffer;
                var offerMultiplier = Convert.ToInt32((basketItem.Value) / itemQuantityOnOfferList.FirstOrDefault()!.ItemQuantityOnOffer);

                if (itemRemainingForOffer < offerMultiplier)
                {
                    offerMultiplier -= 1;
                }

                discountAmount += Math.Round(_items.GetItemPriceByName(itemQuantityOnOfferList.FirstOrDefault()!.ItemOnOffer) * offerMultiplier, 2);
            }

            return discountAmount;
        }

        //public double ApplyAndGetQuantityBasedDiscount(Dictionary<string, int> basketItemQuantity)
        //{
        //    var quantityBasedDiscountItem = _quantityBasedDiscountItem.GetQuantityBasedDiscountItem();
        //    foreach (var basketItem in basketItemQuantity)
        //    {
        //        if (basketItem.Key == quantityBasedDiscountItem.ItemOnOffer)
        //        {
        //            var itemRemainingForOffer = basketItem.Value % quantityBasedDiscountItem.ItemQuantityOnOffer;
        //            var offerMultiplier = Convert.ToInt32((basketItem.Value) / quantityBasedDiscountItem.ItemQuantityOnOffer);

        //            if (itemRemainingForOffer < offerMultiplier)
        //            {
        //                offerMultiplier -= 1;
        //            }

        //            return Math.Round(_items.GetItemPriceByName(quantityBasedDiscountItem.ItemOnOffer) * offerMultiplier, 2);

        //        }
        //    }

        //    return 0;
        //}
    }
}
