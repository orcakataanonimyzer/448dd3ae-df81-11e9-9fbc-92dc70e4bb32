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
    }
}
