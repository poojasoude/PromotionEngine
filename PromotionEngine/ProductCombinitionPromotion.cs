using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class ProductCombinitionPromotion : Promotion
    {
        string fixedSpace = "      ";
        public ProductCombinitionPromotion() : base()
        {
        }

        public Dictionary<long, short> feedProductCombinition = new Dictionary<long, short>();
        HashSet<long> actualProductCombinition = new HashSet<long>();
        public override void Execute(Order product)
        {
            
            if(feedProductCombinition.ContainsKey(product.SKU.Id))
            {
                if(feedProductCombinition[product.SKU.Id] == product.Quantity)
                {
                    actualProductCombinition.Add(product.SKU.Id);
                }

                if(actualProductCombinition.Overlaps(feedProductCombinition.Keys))
                {
                    this.IsEligibleForPromotion = true;
                }
            }
        }
    }
}