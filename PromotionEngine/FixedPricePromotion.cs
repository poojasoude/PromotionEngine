using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class FixedPricePromotion : Promotion
    {
        public FixedPricePromotion() : base()
        {
            
        }

        public short Quantity{get; set;}
        public long ProductId {get;set;}

        private string ProductName{get; set;}

        public override void Execute(Order order)
        {
            if(order.SKU.Id == this.ProductId && order.Quantity >= this.Quantity)
            {
                order.IsEligibleForPromotion = true;
                this.ProductName = order.SKU.Name;

                CalculatePriceForQuantity(order);
            }
        }

        private void CalculatePriceForQuantity(Order order)
        {
            if (order.Quantity == this.Quantity)
            {
                order.PromotionPrice = this.Price;
            }
            else if (order.Quantity > this.Quantity)
            {
                int remainder = 0;
                var quotient = Math.DivRem(order.Quantity, this.Quantity, out remainder);
                order.PromotionPrice = quotient * this.Price;
                order.PromotionPrice =  (order.SKU.Price * remainder) + order.PromotionPrice;
            }
        }
    }
}