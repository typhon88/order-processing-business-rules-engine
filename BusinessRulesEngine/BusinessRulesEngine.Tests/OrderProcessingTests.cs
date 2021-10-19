using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Models;
using BusinessRulesEngine.Proxies;
using BusinessRulesEngine.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static BusinessRulesEngine.Models.Membership;
using static BusinessRulesEngine.Models.Product;

namespace BusinessRulesEngine.Tests
{
    public class Tests
    {
        IOrderProcessingService _processingService;
        IMembershipService _membershipService;

        [SetUp]
        public void Setup()
        {
            _membershipService = new MembershipService();
            _processingService = new OrderProcessingService(_membershipService);
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

        [Test]
        public void Membership_ActivatesMembership()
        {
            Product membership = new()
            {
                Category = ProductCategory.Digital,
                Name = "Some membership name",
                Type = ProductType.Membership
            };

            List<OrderProxy> orders = new()
            {
                new OrderProxy(new List<Product> { membership })
            };

            _membershipService.ClearQueues();
            _processingService.AddForProcessing(orders);
            _processingService.ProcessOrders();

            var numberOfProcessedMemberships = _membershipService.StartProcessing();

            Assert.AreEqual(1, numberOfProcessedMemberships);
            Assert.AreEqual(1, _membershipService.ProcessedMemberships.Count);
            Assert.AreEqual(MembershipType.New, _membershipService.ProcessedMemberships.Single().Type);
        }

        [Test]
        public void Membership_UpgradeMembership()
        {
            Product membership = new()
            {
                Category = ProductCategory.Digital,
                Name = "Some membership name",
                Type = ProductType.MembershipUpgrade
            };

            List<OrderProxy> orders = new()
            {
                new OrderProxy(new List<Product> { membership })
            };

            _membershipService.ClearQueues();
            _processingService.AddForProcessing(orders);
            _processingService.ProcessOrders();

            var numberOfProcessedMemberships = _membershipService.StartProcessing();

            Assert.AreEqual(1, numberOfProcessedMemberships);
            Assert.AreEqual(1, _membershipService.ProcessedMemberships.Count);
            Assert.AreEqual(MembershipType.Upgrade, _membershipService.ProcessedMemberships.Single().Type);
        }
    }
}