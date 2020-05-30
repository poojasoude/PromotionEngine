using System.Collections.Generic;
using PromotionEngine;

namespace PromotionEngine
{
    public interface IEngine
    {
        Dictionary<long, Promotion> promotionRules { get; set; }
        void Evaluate(Order product);
        IEnumerable<Promotion> GetEligiblePromotions();
    }
}
