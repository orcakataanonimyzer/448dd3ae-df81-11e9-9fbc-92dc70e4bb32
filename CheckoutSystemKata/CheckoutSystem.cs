using CheckoutSystemKata.Models;
using CheckoutSystemKata.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutSystemKata
{
    public class CheckoutSystem
    {
        public HashSet<Item> availableItems = new HashSet<Item>();
        public HashSet<Item> scannedItems = new HashSet<Item>();
        private SpecialService specialService = new SpecialService();

        public double checkoutTotal = 0;

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

        public void ScanItem(Item scanItem)
        {
            if (availableItems.Any(ai => ai.Name == scanItem.Name))
            {
                var itemAlreadyScanned = scannedItems.FirstOrDefault(si => si.Name == scanItem.Name);
                if (itemAlreadyScanned == null)
                {
                    scannedItems.Add(scanItem);
                }
                else
                {
                    itemAlreadyScanned.Weight += scanItem.Weight;
                }
            }
            else
            {
                Console.WriteLine("Item not available to scan");
            }
        }

        public void CalculateTotal()
        {
            checkoutTotal = 0;
            foreach(var item in scannedItems)
            {
                var availableItem = availableItems.First(ai => ai.Name == item.Name);
                var numberOfItems = item.Weight / availableItem.Weight;

                if (availableItem.HasSpecial)
                {
                    checkoutTotal += DetermineSpecialTotal(availableItem, item);
                }
                else
                {
                    checkoutTotal += numberOfItems * (availableItem.Price - availableItem.Markdown);
                }
            }
        }

        public double DetermineSpecialTotal(Item availableItem, Item scannedItem)
        {
            switch (availableItem.Special.Type)
            {
                case SpecialType.None:
                    return 0;
                case SpecialType.GetXOffNBuyM:
                    return specialService.CalculateBuyNGetMAtXOffSpecialTotal(availableItem, scannedItem);
                case SpecialType.GetXForM:
                    return specialService.CalculateGetXForMSpecialTotal(availableItem, scannedItem);
                default:
                    return 0;
            }
        }

        public void RemoveScannedItem(Item itemToRemove)
        {
            if (scannedItems.Any(si => si.Name == itemToRemove.Name))
            {
                var itemToAdjust = scannedItems.First(si => si.Name == itemToRemove.Name);
                if (itemToAdjust.Weight == itemToRemove.Weight)
                {
                    scannedItems.Remove(itemToAdjust);
                }
                else
                {
                    itemToAdjust.Weight -= itemToRemove.Weight;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
