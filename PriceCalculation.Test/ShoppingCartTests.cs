using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceCalculation.Discounts;
using PriceCalculation.Repositories;
using System.Collections.Generic;
using FluentAssertions;
using Moq;

namespace PriceCalculation.Test
{

    [TestClass]
    public class ShoppingCartTests
    {
        ShoppingCart _shoppingCart;
        Mock<IHalfPriceDiscount> _mockHalfPriceDiscount;
        Mock<IQuantityBasedDiscount> _mockQuantityBasedDiscount;
        Items _items;

        [TestInitialize]
        public void TestInitialize()
        {
            _items = new Items();

            _mockHalfPriceDiscount = new Mock<IHalfPriceDiscount>();
            _mockQuantityBasedDiscount = new Mock<IQuantityBasedDiscount>();
            _shoppingCart = new ShoppingCart(_items, _mockQuantityBasedDiscount.Object, _mockHalfPriceDiscount.Object);
        }




        [TestMethod]
        [DataRow("Milk", 1.15)]
        [DataRow("Butter", 0.80)]
        [DataRow("Bread", 1.00)]
        public void CalculateTotalPriceOfBasket_ForSingleItem_Should_Return_CorrectPrice(string item, double expectedPrice)
        {
            var items = new List<string>() { item };

            var totalPrice = _shoppingCart.CalculateTotalPriceOfBasket(items);

            totalPrice.Should().Be(expectedPrice);

        }


        [TestMethod]
        public void CalculateTotalPriceOfBasket_With_HalfPriceDiscount_Should_Return_CorrectPrice()
        {
            var items = new List<string>() { "Butter", "Butter", "Bread", "Bread" };

            _mockHalfPriceDiscount.Setup(h => h.ApplyAndGetHalfPriceDiscount(It.IsAny<Dictionary<string, int>>())).Returns(0.50);
            var totalPrice = _shoppingCart.CalculateTotalPriceOfBasket(items);

            totalPrice.Should().Be(3.10);
        }



        [TestMethod]
        public void CalculateTotalPriceOfBasket_With_QuantityBasedDiscount_Should_Return_CorrectPrice()
        {
            var items = new List<string>() { "Milk", "Milk", "Milk", "Milk" };
            _mockQuantityBasedDiscount.Setup(h => h.ApplyAndGetQuantityBasedDiscount(It.IsAny<Dictionary<string, int>>())).Returns(1.15);

            var totalPrice = _shoppingCart.CalculateTotalPriceOfBasket(items);

            totalPrice.Should().Be(3.45);
        }


    }
}
