using BusinessRulesEngine.Proxies;
using System.Collections.Generic;

namespace BusinessRulesEngine.Interfaces
{
    public interface IOrderProcessingService
    {
        void AddForProcessing(List<OrderProxy> orders);

        void ProcessOrders();
    }
}