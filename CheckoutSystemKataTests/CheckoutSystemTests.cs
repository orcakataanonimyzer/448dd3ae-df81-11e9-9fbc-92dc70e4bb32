using CheckoutSystemKata;
using CheckoutSystemKata.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CheckoutSystemKataTests
{
    [TestClass]
    public class CheckoutSystemTests
    {

        CheckoutSystem checkoutSystem = new CheckoutSystem();

        private void AddPeanutsToAvailableItems()
        {
            var item = new Item("peanuts", 2, 1);
            checkoutSystem.AddToAvailableItems(item);
        }

        private void ScanPeanutItem(int timesToScan)
        {
            for (int i = 0; i < timesToScan; i++)
            {
                var item = new Item("peanuts", 2, 1);
                checkoutSystem.ScanItem(item);
            }
        }

        [TestMethod]
        public void should_allow_to_add_items_to_available_items()
        {
            Assert.IsFalse(checkoutSystem.availableItems.Any());
            AddPeanutsToAvailableItems();
            Assert.IsTrue(checkoutSystem.availableItems.Any());
        }

        [TestMethod]
        public void should_not_allow_to_add_two_items_to_available_items_with_same_name()
        {
            AddPeanutsToAvailableItems();
            Assert.IsTrue(checkoutSystem.availableItems.Count == 1);
            AddPeanutsToAvailableItems();
            Assert.IsFalse(checkoutSystem.availableItems.Count == 2);
        }

        [TestMethod]
        public void should_allow_to_scan_an_item()
        {
            AddPeanutsToAvailableItems();
            ScanPeanutItem(1);
            checkoutSystem.CalculateTotal();
            Assert.IsTrue(checkoutSystem.scannedItems.Count == 1);
            Assert.IsTrue(checkoutSystem.scannedItems.First().Name == "peanuts");
            Assert.IsTrue(checkoutSystem.scannedItems.First().Weight == 1);
            Assert.IsTrue(checkoutSystem.checkoutTotal == 2);
        }

        [TestMethod]
        public void should_update_total_correctly_if_scan_same_item_twice()
        {
            AddPeanutsToAvailableItems();
            ScanPeanutItem(2);
            checkoutSystem.CalculateTotal();
            Assert.IsTrue(checkoutSystem.checkoutTotal == 4);
        }

        [TestMethod]
        public void should_not_allow_to_scan_an_item_if_not_an_available_item()
        {
            var item = new Item("nut", 2, 1);
            checkoutSystem.ScanItem(item);
            Assert.IsFalse(checkoutSystem.scannedItems.Count == 1);
        }

        [TestMethod]
        public void should_discount_price_of_the_item_by_the_markdown()
        {
            var markedDownItem = new Item("peanuts", 2, 1, 1);
            checkoutSystem.AddToAvailableItems(markedDownItem);
            ScanPeanutItem(2);
            checkoutSystem.CalculateTotal();
            Assert.IsTrue(checkoutSystem.checkoutTotal == 2);
        }

        [TestMethod]
        public void should_be_able_to_buy_n_get_m_at__x_off_special_for_an_available_item()
        {
            AddPeanutsToAvailableItems();
            checkoutSystem.availableItems.First().Special.AddBuyNGetXOffOfMSpecial(2, 1, .5, null);
            ScanPeanutItem(2);
            checkoutSystem.CalculateTotal();
            Assert.IsTrue(checkoutSystem.checkoutTotal == 3);
        }

        [TestMethod]
        public void should_be_able_to_create_a_special_to_buy_n_get_all_at_discounted_price()
        {
            AddPeanutsToAvailableItems();
            checkoutSystem.availableItems.First().Special.AddBuyNGetAllForMPrice(2, 1, null);
            ScanPeanutItem(2);
            checkoutSystem.CalculateTotal();
            Assert.IsTrue(checkoutSystem.checkoutTotal == 1);
        }

        [TestMethod]
        public void should_be_able_to_place_limit_on_buy_n_get_m_at_x_off_special_for_an_available_item()
        {
            AddPeanutsToAvailableItems();
            checkoutSystem.availableItems.First().Special.AddBuyNGetXOffOfMSpecial(2, 1, .5, 6);
            ScanPeanutItem(9);
            checkoutSystem.CalculateTotal();
            Assert.IsTrue(checkoutSystem.checkoutTotal == 16);
        }

        [TestMethod]
        public void should_be_able_to_place_limit_on_special_to_buy_n_get_akk_at_fixed_cost()
        {
            AddPeanutsToAvailableItems();
            checkoutSystem.availableItems.First().Special.AddBuyNGetAllForMPrice(2, 1, 6);
            ScanPeanutItem(7);
            checkoutSystem.CalculateTotal();
            Assert.IsTrue(checkoutSystem.checkoutTotal == 5);
        }

        [TestMethod]
        public void should_be_able_to_remove_a_scanned_item()
        {
            AddPeanutsToAvailableItems();
            ScanPeanutItem(2);
            Assert.IsTrue(checkoutSystem.scannedItems.First().Weight == 2);
            var itemToRemove = new Item("peanuts", 2, 1);
            checkoutSystem.RemoveScannedItem(itemToRemove);
            Assert.IsTrue(checkoutSystem.scannedItems.First().Weight == 1);
        }
    }
}
