using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutSystemKata.Models
{
    public class Item
    {
        public Item(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
    }
}
