using System.Collections.Generic;

namespace BusinessRulesEngine.Models
{
    internal class Order
    {
        internal List<Product> Products;

        internal List<PackingSlip> PackingSlips;

        internal Order(List<Product> products)
        {
            Products = products;
            PackingSlips = new List<PackingSlip>();
        }
    }
}