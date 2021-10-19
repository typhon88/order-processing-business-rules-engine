using System.Collections.Generic;

namespace BusinessRulesEngine.Models
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