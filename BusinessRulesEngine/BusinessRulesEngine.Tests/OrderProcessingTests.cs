using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Models;
using BusinessRulesEngine.Proxies;
using BusinessRulesEngine.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BusinessRulesEngine.Tests
{
    public class Tests
    {
        IOrderProcessingService _processingService;

        [SetUp]
        public void Setup()
        {
            _processingService = new OrderProcessingService();
        }

        [Test]
        public void PhysicalProduct_GeneratesShippingPackingSlip()
        {
            Product physicalProduct = new();

            List<OrderProxy> orders = new()
            {
                new OrderProxy(new List<Product> { physicalProduct })
            };

            _processingService.AddForProcessing(orders);
            _processingService.ProcessOrders();

            Assert.AreEqual(1, orders.Single().PackingSlips.Count);
            Assert.AreEqual(orders.Single().PackingSlips.Single().Name, "Shipping packing slip");
        }
    }
}