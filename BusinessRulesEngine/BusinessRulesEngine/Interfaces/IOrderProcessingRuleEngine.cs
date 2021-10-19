namespace BusinessRulesEngine.Interfaces
{
    internal interface IOrderProcessingRuleEngine
    {
        void ApplyRules(object order);
    }
}
