using CheckoutSystemKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutSystemKata
{
    public class CheckoutSystem
    {
        public HashSet<Item> availableItems = new HashSet<Item>();

        public CheckoutSystem()
        {

        }

        public void AddToAvailableItems(Item itemToAdd)
        {
            if (availableItems.Any(ai => ai.Name == itemToAdd.Name))
            {
                Console.WriteLine("Cannot add two items with same name to available items");
            }
            else
            {
                availableItems.Add(itemToAdd);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
