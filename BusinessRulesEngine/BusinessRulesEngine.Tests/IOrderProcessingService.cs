using System.Collections.Generic;

namespace BusinessRulesEngine.Tests
{
    public interface IOrderProcessingService
    {
        void AddForProcessing(List<Order> orders);
        void ProcessOrders();
    }
}