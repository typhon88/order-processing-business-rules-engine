using BusinessRulesEngine.Models;
using BusinessRulesEngine.Proxies;
using System.Linq;

namespace BusinessRulesEngine.RulesEngines.OrderProcessing
{
    internal class PhysicalProduct_PackingSlipRule : RuleBase
    {
        internal override bool IsMatch(Product product)
        {
            return product.Category.Equals(Product.ProductCategory.Physical);
        }

        internal override void UpdateOrder(OrderProxy order)
        {
            var packingSlip = new PackingSlip()
            {
                Name = "Shipping packing slip",
                Products = order.Products.ToList()
            }; ;

            order.AddPackingSlip(packingSlip);
        }
    }
}
