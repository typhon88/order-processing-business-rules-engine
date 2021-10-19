using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessRulesEngine.Tests
{
    public class EmailService : IEmailService
    {
        Queue<OrderEmail> _orderEmails = new Queue<OrderEmail>();
        IList<OrderEmail> _processedEmails = new List<OrderEmail>();
        int _numberOfProcessedEmails = 0;

        public EmailService()
        {
        }

        public IReadOnlyCollection<OrderEmail> ProcessedOrderEmails => _processedEmails.ToList();

        public void AddForProcessing(OrderEmail payment)
        {
            _orderEmails.Enqueue(payment);
        }

        bool ProcessNext()
        {
            var email = _orderEmails.Dequeue();

            if (email is not null)
            {
                // TODO Add processing logic

                _processedEmails.Add(email);
                _numberOfProcessedEmails++;
            }

            return _orderEmails.Count > 0;
        }

        public int StartProcessing()
        {
            while (ProcessNext())
            {
            }

            return _numberOfProcessedEmails;
        }

        public void ClearQueues()
        {
            _orderEmails.Clear();
            _processedEmails.Clear();
            _numberOfProcessedEmails = 0;
        }
    }
}