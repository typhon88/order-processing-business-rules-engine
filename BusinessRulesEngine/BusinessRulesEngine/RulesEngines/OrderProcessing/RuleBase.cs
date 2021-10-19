using BusinessRulesEngine.Models;
using BusinessRulesEngine.Proxies;

namespace BusinessRulesEngine.RulesEngines.OrderProcessing
{
    internal abstract class RuleBase
    {
        internal abstract bool IsMatch(Product product);

        internal abstract void UpdateOrder(OrderProxy order);
    }
}