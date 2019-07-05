using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutSystemKata.Models
{
    public class Special
    {
        public double ItemsToBuy { get; set; }
        public double ItemsToDiscount { get; set; }
        public double Discount { get; set; }
        public double FixedDiscountedPrice { get; set; }
        public SpecialType Type = 0;
        public double Limit { get; set; }
        public double WeightToBuy { get; set; }
        public double WeightDiscounted { get; set; }

        public void AddBuyNGetXOffOfMSpecial(double itemsToBuy, double itemsToDiscount, double discount, double? limit)
        {
            Type = SpecialType.GetXOffNBuyM;
            ItemsToBuy = itemsToBuy;
            ItemsToDiscount = itemsToDiscount;
            Discount = discount;
            Limit = limit ?? 0;
        }

        public void AddBuyNGetAllForMPrice(int itemsToBuy, double fixedDiscountedPrice, double? limit)
        {
            Type = SpecialType.GetXForM;
            ItemsToBuy = itemsToBuy;
            FixedDiscountedPrice = fixedDiscountedPrice;
            Limit = limit ?? 0;
        }

        public void AddBuyNWeightGetMWeightForDiscount(int weightToBuy, double weightDiscounted, double discount, double? limit)
        {
            Type = SpecialType.GetNWeightMWeightDiscount;
            WeightToBuy = weightToBuy;
            WeightDiscounted = weightDiscounted;
            Discount = discount;
            Limit = limit ?? 0;
        }
    }
}
