using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Models;
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
        }

        [Test]
        public void PhysicalProduct_GeneratesShippingPackingSlip()
        {
            Product physicalProduct = new();

            List<Order> orders = new()
            {
                new Order(new List<Product> { physicalProduct })
            };

            _processingService.AddForProcessing(orders);
            _processingService.ProcessOrders();

            Assert.AreEqual(1, orders.Single().PackingSlips.Count);
        }
    }
}