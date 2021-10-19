using BusinessRulesEngine.Models;
using BusinessRulesEngine.Proxies;
using System.Linq;

namespace BusinessRulesEngine.RulesEngines.OrderProcessing.Rules
{
    internal class Book_RoyaltyDepartmentPackingSlip : RuleBase
    {
        internal override bool IsMatch(Product product)
        {
            return product.Category.Equals(Product.ProductCategory.Physical) &&
                product.Type.Equals(Product.ProductType.Book);
        }

        internal override void UpdateOrder(OrderProxy order)
        {
            var packingSlip = new PackingSlip()
            {
                Name = "Royalty department slip",
                Products = order.Products.ToList()
            };

            order.AddPackingSlip(packingSlip);
        }
    }
}
