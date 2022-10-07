using PriceCalculation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCalculation.Discounts
{
    public class HalfPriceDiscount : IHalfPriceDiscount
    {
        private IHalfPriceDiscountItem _halfPriceDiscountItem;
        private IItems _items;

        public HalfPriceDiscount(IHalfPriceDiscountItem halfPriceDiscountItem, IItems items)
        {
            _halfPriceDiscountItem = halfPriceDiscountItem;
            _items = items;
        }

        //Todo change basketItemQuantity to basketCollection object
        public double ApplyAndGetHalfPriceDiscount(Dictionary<string, int> basketItemQuantity)
        {
            var halfPriceDiscountItem = _halfPriceDiscountItem.GetHalfPriceDiscountItem();
            foreach (var basketItem in basketItemQuantity)
            {

                // If discount item is not there in the basket, there is nothing to discount
                var basketItemOnDiscount = basketItemQuantity.Where(i => i.Key == halfPriceDiscountItem.ItemOnDiscount).ToList();
                if (basketItemOnDiscount.Count == 0)
                {
                    return 0;
                }

                if (basketItem.Key != halfPriceDiscountItem.ItemThatQualifyForDiscount ||
                    basketItem.Value < halfPriceDiscountItem.ItemQuantityThatQualifyForDiscount) continue;

                var totalQuantityOffer = Convert.ToInt32(basketItem.Value / halfPriceDiscountItem.ItemQuantityThatQualifyForDiscount);

                // if totalQuantityOffer is greater than discountItem quantity, then totalQuantityOffer should be same as discountItem quantity
                if (totalQuantityOffer > basketItemOnDiscount[0].Value)
                {
                    totalQuantityOffer = basketItemOnDiscount[0].Value;
                }

                return _items.GetItemPriceByName(halfPriceDiscountItem.ItemOnDiscount) * totalQuantityOffer * 50 / 100;
            }

            return 0;
        }
    }
}
