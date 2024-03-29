﻿using CheckoutSystemKata.Models;

namespace CheckoutSystemKata.Services
{
    public class SpecialService
    {
        public SpecialService()
        {

        }

        public double CalculateBuyNGetMAtXOffSpecialTotal(Item availableItem, Item scannedItem)
        {
            int numberScanned = (int)(scannedItem.Weight / availableItem.Weight);
            if (numberScanned >= availableItem.Special.ItemsToBuy)
            {
                double discountedTotal = 0;
                double fullPriceTotal = 0;
                var itemsToDiscount = numberScanned / availableItem.Special.ItemsToBuy;
                var itemHasLimit = availableItem.Special.Limit > 0;
                var timesAllowedToDiscount = itemHasLimit ? (availableItem.Special.Limit / (availableItem.Special.ItemsToBuy + availableItem.Special.ItemsToDiscount)) : 0;

                itemsToDiscount = timesAllowedToDiscount != 0 && itemsToDiscount > timesAllowedToDiscount ? (int)timesAllowedToDiscount : itemsToDiscount;
                discountedTotal += itemsToDiscount * (availableItem.Price * availableItem.Special.Discount);
                fullPriceTotal += (numberScanned - itemsToDiscount) * availableItem.Price;

                return discountedTotal + fullPriceTotal;
            }
            else
            {
                return numberScanned * availableItem.Price;
            }
        }

        public double CalculateGetXForMSpecialTotal(Item availableItem, Item scannedItem)
        {
            double numberScanned = scannedItem.Weight / availableItem.Weight;
            if (numberScanned >= availableItem.Special.ItemsToBuy)
            {
                var timesToDiscount = (int)(numberScanned / availableItem.Special.ItemsToBuy);
                var itemHasLimit = availableItem.Special.Limit > 0;
                timesToDiscount = itemHasLimit ? (int)(availableItem.Special.Limit / availableItem.Special.ItemsToBuy) : timesToDiscount;
                var remainingItems = numberScanned - (timesToDiscount * availableItem.Special.ItemsToBuy);

                var discountedCost = timesToDiscount * availableItem.Special.FixedDiscountedPrice;
                var fullPriceItems = remainingItems * availableItem.Price;

                return discountedCost + fullPriceItems;
            }
            else
            {
                return numberScanned * availableItem.Price;
            }
        }

        public double CalculateBuyNWeightGetMWeightDiscountSpecialTotal(Item availableItem, Item scannedItem)
        {
            double totalWeight = scannedItem.Weight;
            if (totalWeight >= availableItem.Special.WeightToBuy)
            {
                double discountedTotal = 0;
                double fullPriceTotal = 0;

                var weightNeededForDiscount = availableItem.Special.WeightToBuy + availableItem.Special.WeightDiscounted;
                var itemHasLimit = availableItem.Special.Limit > 0;
                var timesToApplyDiscount = (int)(totalWeight / weightNeededForDiscount);
                var maxTimesAllowedToApplyDiscount = (int)(availableItem.Special.Limit / weightNeededForDiscount);

                timesToApplyDiscount = itemHasLimit && timesToApplyDiscount > maxTimesAllowedToApplyDiscount ? maxTimesAllowedToApplyDiscount : timesToApplyDiscount;
                var weightToDiscount = availableItem.Special.WeightDiscounted * timesToApplyDiscount;

                discountedTotal = weightToDiscount * (availableItem.Price * availableItem.Special.Discount);
                fullPriceTotal = (scannedItem.Weight - weightToDiscount) * availableItem.Price;
                return discountedTotal + fullPriceTotal;
            }
            else
            {
                return (totalWeight / availableItem.Weight) * availableItem.Price;
            }
        }
    }
}
