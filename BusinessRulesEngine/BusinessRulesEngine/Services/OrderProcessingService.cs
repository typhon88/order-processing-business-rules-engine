using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Proxies;
using System.Collections.Generic;

namespace BusinessRulesEngine.Services
{
    public class OrderProcessingService : IOrderProcessingService
    {
        public void AddForProcessing(List<OrderProxy> orders)
        {
            throw new System.NotImplementedException();
        }

        public void ProcessOrders()
        {
            throw new System.NotImplementedException();
        }
    }
}
