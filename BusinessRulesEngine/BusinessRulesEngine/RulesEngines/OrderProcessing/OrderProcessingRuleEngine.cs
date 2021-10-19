using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Services;
using System.Collections.Generic;

namespace BusinessRulesEngine.RulesEngines.OrderProcessing
{
    internal class OrderProcessingRuleEngine : IOrderProcessingRuleEngine
    {
        private List<RuleBase> rules;

        public OrderProcessingRuleEngine(List<RuleBase> rules)
        {
            this.rules = rules;
        }

        public void ApplyRules(object order)
        {
            throw new System.NotImplementedException();
        }
    }
}
