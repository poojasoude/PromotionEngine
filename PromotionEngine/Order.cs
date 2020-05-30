using System;

namespace PromotionEngine
{
    public class SKU
    {
        public long Id {get;set;}
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Order
    {
        public SKU SKU { get; set; }
        public int PromotionId { get; set; }
        public short Quantity { get; set; }

        public decimal? TotalPrice
        {
            get { return SKU?.Price * Quantity; }
        }

        public decimal? PromotionPrice { get; set; }
        public bool IsEligibleForPromotion { get; set; }
    }
}