using BusinessRulesEngine.Models;
using BusinessRulesEngine.Proxies;

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
            var packingSlip = order.GetShippingPackingSlip();

            order.AddPackingSlip(packingSlip);
        }
    }
}
