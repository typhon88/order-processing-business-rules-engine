using BusinessRulesEngine.Models;
using BusinessRulesEngine.Proxies;

namespace BusinessRulesEngine.RulesEngines.OrderProcessing
{
    internal class PhysicalProduct_PackingSlipRule : RuleBase
    {
        internal override bool IsMatch(Product product)
        {
            throw new System.NotImplementedException();
        }

        internal override void UpdateOrder(OrderProxy order)
        {
            throw new System.NotImplementedException();
        }
    }
}
