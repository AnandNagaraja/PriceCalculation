using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceCalculation.Discounts;
using PriceCalculation.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace PriceCalculation.Test.Discounts
{

    [TestClass]
    public class QuantityBasedDiscountTests
    {
        QuantityBasedDiscount _quantityBasedDiscount;
        QuantityBasedDiscountItem _quantityBasedDiscountItem;
        Items _items;


        [TestInitialize]
        public void TestInitialize()
        {
            _items = new Items();
            _quantityBasedDiscountItem = new QuantityBasedDiscountItem();

            _quantityBasedDiscount = new QuantityBasedDiscount(_quantityBasedDiscountItem, _items);
        }


        [TestMethod]
        [DataRow(1, 0.00)]
        [DataRow(3, 0.00)]
        [DataRow(4, 1.15)]
        [DataRow(7, 1.15)]
        [DataRow(8, 2.30)]
        [DataRow(9, 2.30)]
        [DataRow(10, 2.30)]
        [DataRow(11, 2.30)]
        [DataRow(12, 3.45)]
        [DataRow(13, 3.45)]
        [DataRow(14, 3.45)]
        [DataRow(15, 4.60)]
        [DataRow(16, 4.60)]
        public void ApplyAndGetQuantityBasedDiscount_WithOffer_Should_ReturnValid_Discount(int quantity, double expectedDiscount)
        {
            var basketItemQuantity = new Dictionary<string, int>();
            basketItemQuantity.Add("Milk", quantity);

            var discountPrice = _quantityBasedDiscount.ApplyAndGetQuantityBasedDiscount(basketItemQuantity);

            discountPrice.Should().Be(expectedDiscount);
        }



    }
}
