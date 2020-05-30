using System;

namespace PromotionEngine
{
    public abstract class Promotion
    {
        public int PromotionId{get;set;}
        public DateTime ExpiryDate{get; set;}
        public decimal Price {get; set;}
        public bool IsEligibleForPromotion{get; set;}
        public abstract void Execute(Order product);
    }
}