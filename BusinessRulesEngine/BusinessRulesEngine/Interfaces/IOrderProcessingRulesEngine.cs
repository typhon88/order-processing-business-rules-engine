namespace BusinessRulesEngine.Interfaces
{
    internal interface IOrderProcessingRulesEngine
    {
        void ApplyRules(object order);
    }
}
