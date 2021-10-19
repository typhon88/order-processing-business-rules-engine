using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Models;
using BusinessRulesEngine.Proxies;

namespace BusinessRulesEngine.RulesEngines.OrderProcessing.Rules
{
    internal class Membership_ActivationRule : RuleBase
    {
        IMembershipService _membershipService;
        IEmailService _emailService;

        internal Membership_ActivationRule(IMembershipService membershipService, IEmailService emailService)
        {
            _membershipService = membershipService;
            _emailService = emailService;
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

            var email = new OrderEmail("You have activated a new membership");

            _emailService.AddForProcessing(email);
        }
    }
}
