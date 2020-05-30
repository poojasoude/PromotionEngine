using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class Engine : IEngine
    {
        public Dictionary<long, Promotion> promotionRules { get; set; }
        public Engine()
        {
            promotionRules = new Dictionary<long, Promotion>();
        }

        public void Evaluate(Order product)
        {
            if(promotionRules.ContainsKey(product.PromotionId))
            {
                promotionRules[product.PromotionId].Execute(product);
            }
        }

        public IEnumerable<Promotion> GetEligiblePromotions()
        {
            return this.promotionRules.Values.Where(c => c.IsEligibleForPromotion);
        }
    }
}