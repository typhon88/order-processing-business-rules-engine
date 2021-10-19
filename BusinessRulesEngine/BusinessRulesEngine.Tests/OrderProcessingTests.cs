using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Models;
using BusinessRulesEngine.Proxies;
using BusinessRulesEngine.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static BusinessRulesEngine.Models.Product;

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
            Product physicalProduct = new()
            {
                Category = ProductCategory.Physical,
                Name = "Some physical product",
                Type = ProductType.Generic
            };

            List<OrderProxy> orders = new()
            {
                new OrderProxy(new List<Product> { physicalProduct })
            };

            _processingService.AddForProcessing(orders);
            _processingService.ProcessOrders();

            Assert.AreEqual(1, orders.Single().PackingSlips.Count);
            Assert.AreEqual(orders.Single().PackingSlips.Single().Name, "Shipping packing slip");
        }

        [Test]
        public void Book_GeneratesShippingAndRoyaltyPackingSlips()
        {
            Product book = new()
            {
                Category = ProductCategory.Physical,
                Name = "Some book name",
                Type = ProductType.Book
            };

            List<OrderProxy> orders = new()
            {
                new OrderProxy(new List<Product> { book })
            };

            _processingService.AddForProcessing(orders);
            _processingService.ProcessOrders();

            Assert.AreEqual(2, orders.First().PackingSlips.Count);
        }
    }
}