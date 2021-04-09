using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculation.Repositories
{
    public class Items : IItems
    {
        public double GetItemPriceByName(string itemName)
        {
            var itemCollection = new Dictionary<string, double> { { "Butter", 0.80 }, { "Milk", 1.15 }, { "Bread", 1.00 } };
            return itemCollection[itemName];
        }

    }
}
