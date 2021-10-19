using System.Collections.Generic;

namespace BusinessRulesEngine.Tests
{
    public class Order
    {
        private List<Product> products;

        public Order(List<Product> products)
        {
            this.products = products;
        }

        public ICollection<PackingSlip> PackingSlips { get; set; }
    }
}