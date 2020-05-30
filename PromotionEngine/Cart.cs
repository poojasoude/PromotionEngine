using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class Cart
    {
        public List<Order> Orders { get; set; }
        public List<Promotion> Promotions {get; set;}
        public decimal GetTotalPrice()
        {
            decimal totalValue = 0;
            //Promotions.ForEach(c => {
            //    totalValue = totalValue - c.Price;
            //});

            Orders.ForEach(c =>
            {
                if (c.IsEligibleForPromotion)
                {
                    totalValue = totalValue + c.PromotionPrice.Value;
                }
                else
                {
                    if (c.TotalPrice != null)
                    {
                        totalValue = totalValue + c.TotalPrice.Value;
                    }
                }
            });


            return totalValue;
        }
    }
}