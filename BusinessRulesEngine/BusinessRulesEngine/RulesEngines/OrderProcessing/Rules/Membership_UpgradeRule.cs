using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Models;
using BusinessRulesEngine.Proxies;

namespace BusinessRulesEngine.RulesEngines.OrderProcessing.Rules
{
    internal class Membership_UpgradeRule : RuleBase
    {
        IMembershipService _membershipService;
        IEmailService _emailService;

        internal Membership_UpgradeRule(IMembershipService membershipService, IEmailService emailService)
        {
            _membershipService = membershipService;
            _emailService = emailService;
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

            var email = new OrderEmail("You have upgraded your membership");

            _emailService.AddForProcessing(email);
        }
    }
}
