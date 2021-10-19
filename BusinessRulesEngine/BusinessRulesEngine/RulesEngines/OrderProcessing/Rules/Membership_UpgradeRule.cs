using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Models;
using BusinessRulesEngine.Proxies;

namespace BusinessRulesEngine.RulesEngines.OrderProcessing.Rules
{
    internal class Membership_UpgradeRule : RuleBase
    {
        IMembershipService _membershipService;

        internal Membership_UpgradeRule(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        internal override bool IsMatch(Product product)
        {
            return product.Category.Equals(Product.ProductCategory.Digital) &&
                product.Type.Equals(Product.ProductType.MembershipUpgrade);
        }

        internal override void UpdateOrder(OrderProxy order)
        {
            var membership = new Membership(Membership.MembershipType.Upgrade);

            _membershipService.AddForProcessing(membership);
        }
    }
}
