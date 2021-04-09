using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceCalculation.Discounts;
using PriceCalculation.Repositories;
using System.Collections.Generic;
using FluentAssertions;

namespace PriceCalculation.Test.Discounts
{
    [TestClass]
    public class HalfPriceDiscountTests
    {
        HalfPriceDiscount _halfPriceDiscount;
        HalfPriceDiscountItem _halfPriceDiscountItem;

        Items _items;


        [TestInitialize]
        public void TestInitialize()
        {
            _items = new Items();
            _halfPriceDiscountItem = new HalfPriceDiscountItem();

            _halfPriceDiscount = new HalfPriceDiscount(_halfPriceDiscountItem, _items);
        }


        [TestMethod]
        [DataRow(4, 0, 0.00)]
        [DataRow(1, 1, 0.00)]
        [DataRow(2, 1, 0.50)]
        [DataRow(3, 1, 0.50)]
        [DataRow(4, 1, 0.50)]
        [DataRow(4, 2, 1.00)]
        [DataRow(6, 3, 1.50)]
        public void ApplyAndGetHalfPriceDiscount_WithOneOffer_Should_Return_Valid_Discount(int butterQuantity, int breadQuantity, double expectedDiscount)
        {
            var basketItemQuantity = new Dictionary<string, int> { { "Butter", butterQuantity }, { "Bread", breadQuantity } };

            var discountPrice = _halfPriceDiscount.ApplyAndGetHalfPriceDiscount(basketItemQuantity);

            discountPrice.Should().Be(expectedDiscount);

        }



    }


}
