using BusinessRulesEngine.Models;
using System.Collections.Generic;

namespace BusinessRulesEngine.Interfaces
{
    public interface IEmailService
    {
        IReadOnlyCollection<OrderEmail> ProcessedOrderEmails { get; }

        void AddForProcessing(OrderEmail payment);

        int StartProcessing();

        void ClearQueues();
    }
}