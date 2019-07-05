using CheckoutSystemKata.Models;

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
    }
}
