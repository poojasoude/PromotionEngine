using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class CartManager
    {
        Cart orderList;
        public Cart OrderList => orderList;

        public CartManager()
        {
            CreateCart();
        }

        private void CreateCart()
        {
            orderList = new Cart();
            orderList.Orders = new List<Order>();
            orderList.Promotions = new List<Promotion>();
        }
        public void Add(Order product)
        {
            orderList.Orders.Add(product);
        }

        private void ApplyPromotion(IEngine promotionEngine)
        {
            foreach (var item in orderList.Orders)
            {
                promotionEngine.Evaluate(item);
            }

            orderList.Promotions.AddRange(promotionEngine.GetEligiblePromotions());
        }

        public void CheckOut(IEngine promotionEngine)
        {
            if (promotionEngine != null)
            {
                ApplyPromotion(promotionEngine);
            }
        }

        //public string CartStatement()
        //{
        //    string fixedSpace = "      ";
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("***********************************");
        //    sb.AppendLine();
        //    sb.Append("Order in Carts");
        //    sb.AppendLine();
        //    sb.AppendFormat($"Product{fixedSpace}Quantity{fixedSpace}Price");
        //    sb.AppendLine();

        //    orderList.Products.ForEach(c=> {
        //        sb.AppendLine();
        //        sb.AppendFormat($"{c.SKU.Name}{fixedSpace}{fixedSpace}{c.Quantity}{fixedSpace}{fixedSpace}{c.SKU.Price}");
        //        sb.AppendLine();
        //    });

        //    sb.AppendFormat($"{fixedSpace}{fixedSpace}Total{fixedSpace}{fixedSpace}{orderList.CalculateTotalPrice().ToString()}");
        //    sb.AppendLine("");
        //    sb.Append("***********************************");
        //    sb.AppendLine();
        //    sb.Append("After Promotion price");
        //    sb.AppendLine();
        //    sb.AppendFormat($"Product{fixedSpace}Quantity{fixedSpace}Price");
        //    orderList.Promotions.ForEach(c=> {
        //        sb.AppendLine();
        //        sb.Append(c.Print());
        //    });

        //    sb.AppendLine();
        //    sb.Append($"{fixedSpace}{fixedSpace}Total{fixedSpace}{fixedSpace}{orderList.CalculateAfterPromotionPrice().ToString()}");
        //    sb.AppendLine();
        //    return sb.ToString();
        //}
    }
}