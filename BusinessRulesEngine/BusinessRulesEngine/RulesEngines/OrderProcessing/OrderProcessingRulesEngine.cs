using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Models;
using BusinessRulesEngine.Proxies;
using System.Collections.Generic;

namespace BusinessRulesEngine.RulesEngines.OrderProcessing
{
    internal class OrderProcessingRulesEngine : IOrderProcessingRulesEngine
    {
        IEnumerable<RuleBase> _rules;

        public OrderProcessingRulesEngine(IEnumerable<RuleBase> rules)
        {
            _rules = rules;
        }

        public void ApplyRules(OrderProxy order)
        {
            foreach (var product in order.Products)
            {
                foreach (var rule in _rules)
                {
                    if (rule.IsMatch(product))
                    {
                        rule.UpdateOrder(order);
                    }
                }
            }
        }
    }
}
