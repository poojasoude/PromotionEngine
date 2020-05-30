using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class TestData
    {
        public static SKU A = new SKU()
        {
            Name = "A",
            Price = 50,
            Id = 1
        };

        public static SKU B  = new SKU()
        {
            Name = "B",
            Price = 30,
            Id = 2
        };

        public static SKU C = new SKU()
        {
            Name = "C",
            Price = 20,
            Id = 3
        };

        public static SKU D = new SKU()
        {
            Name = "D",
            Price = 10,
            Id = 4
        };

        public static List<Promotion> GetPromotions()
        {
            FixedPricePromotion PromotionA = new FixedPricePromotion(){
                Price = 130,
                Quantity = 3,
                PromotionId = 1,
                ProductId = 1
            };

            FixedPricePromotion PromotionB = new FixedPricePromotion()
            {
                Price = 45,
                Quantity = 2,
                PromotionId = 2,
                ProductId = 2
            };

            ProductCombinitionPromotion PromotionCD = new ProductCombinitionPromotion(){
                PromotionId = 3,
                Price = 30,
                feedProductCombinition = new Dictionary<long, short>(){{3, 1},{4, 1}}
            };

            var list = new List<Promotion>();
            list.AddRange(new Promotion[]{PromotionA, PromotionB, PromotionCD });
            return list;
        }

    }
}