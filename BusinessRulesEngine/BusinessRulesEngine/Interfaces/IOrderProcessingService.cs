using BusinessRulesEngine.Models;
using System.Collections.Generic;

namespace BusinessRulesEngine.Interfaces
{
    public interface IOrderProcessingService
    {
        void AddForProcessing(List<Order> orders);
        void ProcessOrders();
    }
}