using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace PromotionEngineTests
{
    [TestClass()]
    public class Scenario
    {
        [TestMethod]
        public void ScenarioATest()
        {
            CartManager cartManager = new CartManager();

            Order orderA = new Order()
            {
                SKU = TestData.A,
                Quantity = 1,
                PromotionId = 1
            };

            Order orderB = new Order()
            {
                SKU = TestData.B,
                PromotionId = 2,
                Quantity = 1
            };

            Order orderC = new Order()
            {
                SKU = TestData.C,
                PromotionId = 2,
                Quantity = 1,
            };

            cartManager.Add(orderA);
            cartManager.Add(orderB);
            cartManager.Add(orderC);

            Assert.IsTrue(cartManager.OrderList.GetTotalPrice() == 100);
        }

        [TestMethod]
        public void ScenarioBTest()
        {
            CartManager cartManager = new CartManager();

            Order orderA = new Order()
            {
                SKU = TestData.A,
                Quantity = 5,
                PromotionId = 1
            };

            Order orderB = new Order()
            {
                SKU = TestData.B,
                PromotionId = 2,
                Quantity = 5
            };

            Order orderC = new Order()
            {
                SKU = TestData.C,
                PromotionId = 2,
                Quantity = 1,
            };

            cartManager.Add(orderA);
            cartManager.Add(orderB);
            cartManager.Add(orderC);

            var rules = TestData.GetPromotions();

            IEngine promotionEngine = new Engine();

            rules.ForEach(c =>
            {
                promotionEngine.promotionRules.Add(c.PromotionId, c);
            });
            

            cartManager.CheckOut(promotionEngine);
            Assert.IsTrue(cartManager.OrderList.GetTotalPrice() == 370);
        }

        [TestMethod]
        public void ScenarioCTest()
        {
            CartManager cartManager = new CartManager();

            Order orderA = new Order()
            {
                SKU = TestData.A,
                Quantity = 3,
                PromotionId = 1
            };

            Order orderB = new Order()
            {
                SKU = TestData.B,
                PromotionId = 2,
                Quantity = 5
            };

            Order orderC = new Order()
            {
                SKU = TestData.C,
                PromotionId = 3,
                Quantity = 1,
            };

            Order orderD = new Order()
            {
                SKU = TestData.D,
                PromotionId = 3,
                Quantity = 1,
            };

            cartManager.Add(orderA);
            cartManager.Add(orderB);
            cartManager.Add(orderC);
            cartManager.Add(orderD);

            var rules = TestData.GetPromotions();

            IEngine promotionEngine = new Engine();

            rules.ForEach(c =>
            {
                promotionEngine.promotionRules.Add(c.PromotionId, c);
            });


            cartManager.CheckOut(promotionEngine);
            Assert.IsTrue(cartManager.OrderList.GetTotalPrice() == 280);
        }
    }
}
