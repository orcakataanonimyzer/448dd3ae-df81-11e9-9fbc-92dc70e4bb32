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
        public SpecialType Type = 0;

        public void AddBuyNGetXOffOfMSpecial(double itemsToBuy, double itemsToDiscount, double discount)
        {
            Type = SpecialType.GetXOffNBuyM;
            ItemsToBuy = itemsToBuy;
            ItemsToDiscount = itemsToDiscount;
            Discount = discount;
        }
    }
}
