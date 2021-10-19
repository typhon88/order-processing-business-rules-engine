using BusinessRulesEngine.Models;
using System.Collections.Generic;

namespace BusinessRulesEngine.Proxies
{
    public class OrderProxy
    {
        Order _order;

        public OrderProxy(List<Product> products)
        {
            _order = new Order(products);
        }

        public IReadOnlyCollection<Product> Products => _order.Products;

        public IReadOnlyCollection<PackingSlip> PackingSlips => _order.PackingSlips;

        internal void AddPackingSlip(PackingSlip packingSlip)
        {
            _order.PackingSlips.Add(packingSlip);
        }
    }
}
