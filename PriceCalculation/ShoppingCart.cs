using PriceCalculation.Discounts;
using PriceCalculation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly Items _items;
        private readonly IHalfPriceDiscount _halfPriceDiscount;
        private readonly IQuantityBasedDiscount _quantityBasedDiscount;

        public ShoppingCart(Items items, IQuantityBasedDiscount quantityBasedDiscount, IHalfPriceDiscount halfPriceDiscount)
        {
            _items = items;
            _quantityBasedDiscount = quantityBasedDiscount;
            _halfPriceDiscount = halfPriceDiscount;
        }

        private static Dictionary<string, int> GetItemsAndQuantities(IEnumerable<string> items)
        {
            var itemsAndQuantities = new Dictionary<string, int>();
            foreach (var item in items)
            {
                if (itemsAndQuantities.ContainsKey(item))
                {
                    itemsAndQuantities[item] += 1;
                }
                else
                {
                    itemsAndQuantities.Add(item, 1);
                }
            }

            return itemsAndQuantities;
        }

        private double CalculateSubTotalPriceOfBasket(Dictionary<string, int> itemsAndQuantities)
        {
            return itemsAndQuantities.Sum(itemAndQuantity => _items.GetItemPriceByName(itemAndQuantity.Key) * itemAndQuantity.Value);
        }

        private double GetTotalDiscountPrice(Dictionary<string, int> itemsAndQuantities)
        {
            var halfPriceDiscount = _halfPriceDiscount.ApplyAndGetHalfPriceDiscount(itemsAndQuantities);
            var quantityBasedDiscount = _quantityBasedDiscount.ApplyAndGetQuantityBasedDiscount(itemsAndQuantities);
            return halfPriceDiscount + quantityBasedDiscount;
        }

        public double CalculateTotalPriceOfBasket(IEnumerable<string> items)
        {
            var itemsAndQuantities = GetItemsAndQuantities(items);
            var subTotal = CalculateSubTotalPriceOfBasket(itemsAndQuantities);
            var discountPrice = GetTotalDiscountPrice(itemsAndQuantities);

            return Math.Round(subTotal - discountPrice, 2);
        }
    }
}
