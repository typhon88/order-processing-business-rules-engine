using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Models;
using BusinessRulesEngine.Proxies;

namespace BusinessRulesEngine.RulesEngines.OrderProcessing.Rules
{
    internal class Membership_ActivationRule : RuleBase
    {
        IMembershipService _membershipService;

        public Membership_ActivationRule(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        internal override bool IsMatch(Product product)
        {
            return product.Category.Equals(Product.ProductCategory.Digital) &&
                product.Type.Equals(Product.ProductType.Membership);
        }

        internal override void UpdateOrder(OrderProxy order)
        {
            var membership = new Membership(Membership.MembershipType.New);

            _membershipService.AddForProcessing(membership);
        }
    }
}
