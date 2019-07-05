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

        public void AddBuyNGetXOffOfMSpecial(double itemsToBuy, double itemsToDiscount, double discount)
        {
            Type = SpecialType.GetXOffNBuyM;
            ItemsToBuy = itemsToBuy;
            ItemsToDiscount = itemsToDiscount;
            Discount = discount;
        }

        public void AddBuyNGetAllForMPrice(int itemsToBuy, double fixedDiscountedPrice)
        {
            Type = SpecialType.GetXForM;
            ItemsToBuy = itemsToBuy;
            FixedDiscountedPrice = fixedDiscountedPrice;
        }
    }
}
