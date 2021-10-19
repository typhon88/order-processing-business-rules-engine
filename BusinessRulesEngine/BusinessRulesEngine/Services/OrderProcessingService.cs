﻿using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Proxies;
using BusinessRulesEngine.RulesEngines.OrderProcessing;
using BusinessRulesEngine.RulesEngines.OrderProcessing.Rules;
using System.Collections.Generic;

namespace BusinessRulesEngine.Services
{
    public class OrderProcessingService : IOrderProcessingService
    {
        Queue<OrderProxy> _orders = new Queue<OrderProxy>();
        IMembershipService _membershipService;

        public OrderProcessingService(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public void AddForProcessing(List<OrderProxy> orders)
        {
            foreach (OrderProxy order in orders)
            {
                _orders.Enqueue(order);
            }
        }

        public void ProcessOrders()
        {
            for (var i = 0; i < _orders.Count; i++)
            {
                ProcessSingleOrder(_orders.Dequeue());
            }
        }

        private void ProcessSingleOrder(OrderProxy order)
        {
            var rules = new List<RuleBase>()
            {
                new PhysicalProduct_PackingSlipRule(),
                new Book_RoyaltyDepartmentPackingSlip(),
                new Membership_ActivationRule(_membershipService)
            };

            IOrderProcessingRulesEngine engine = new OrderProcessingRulesEngine(rules);

            engine.ApplyRules(order);
        }
    }
}
