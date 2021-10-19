using BusinessRulesEngine.Proxies;

namespace BusinessRulesEngine.Interfaces
{
    internal interface IOrderProcessingRulesEngine
    {
        void ApplyRules(OrderProxy order);
    }
}
