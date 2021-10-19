using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Services;
using System.Collections.Generic;

namespace BusinessRulesEngine.RulesEngines.OrderProcessing
{
    internal class OrderProcessingRulesEngine : IOrderProcessingRulesEngine
    {
        private List<RuleBase> rules;

        public OrderProcessingRulesEngine(List<RuleBase> rules)
        {
            this.rules = rules;
        }

        public void ApplyRules(object order)
        {
            throw new System.NotImplementedException();
        }
    }
}
