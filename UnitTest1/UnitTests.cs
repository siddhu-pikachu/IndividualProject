/******************************************************************************
* Filename    = UnitTests.cs
*
* Author      = Rapeti Siddhu Neehal
*
* Product     = FacadeDesignPattern
* 
* Project     = UnitTests
*
* Description = Unit tests for the Facade Design Pattern.
*****************************************************************************/

using ECommerse;

namespace UnitTests
{
    /// <summary>
    /// Class that contains all the Test Methods.
    /// </summary>
    [TestClass]
    public class UnitTests
    {
        /// <summary>
        /// Tests successful payment.
        /// </summary>
        [TestMethod]
        public void SuccessfulPayment ()
        {
            Inventory newInventory1 = new();
            newInventory1.InventoryCheck(1, "mangoe", 12, 13, "Store@123");

            Order newOrder1 = new();
            string invoice = newOrder1.PlaceOrder(1, "mangoe", 3, newInventory1);

            Assert.AreEqual(invoice, "Payment completed!, 3 mangoe ordered for 36. Payment ID is 1.");
        }

        /// <summary>
        /// Tests if the product id's are distinct.
        /// </summary>
        [TestMethod]
        public void DistinctProductIdCheck()
        {
            Inventory newInventory2 = new();
            newInventory2.InventoryCheck(1, "mangoe", 12, 13, "Store@123");
            newInventory2.InventoryCheck(2, "apple", 9, 4, "Store@123");
            newInventory2.InventoryCheck(3, "banana", 3, 24, "Store@123");
            
            Order newOrder2 = new();
            string invoice = newOrder2.PlaceOrder(1, "apple", 3, newInventory2);

            Assert.AreEqual(invoice, "different product is using the id 1 already exists!");

        }

        /// <summary>
        /// Tests addition of product to inventory.
        /// </summary>
        [TestMethod]
        public void AddingNewProduct()
        {
            Inventory newInventory3 = new();
            string inventoryUpdate = newInventory3.InventoryCheck(2, "apple", 9, 4, "Store@123");

            Assert.AreEqual(inventoryUpdate, "product added to inventory!");
        }

        /// <summary>
        /// Tests if user wants to buy a non existant product.
        /// </summary>
        [TestMethod]
        public void UnexistantProduct()
        {
            Inventory newInventory4 = new();
            newInventory4.InventoryCheck(3, "banana", 3, 24, "Store@123");
            Order newOrder4 = new();
            string invoice = newOrder4.PlaceOrder(1, "mangoe", 3, newInventory4);

            Assert.AreEqual(invoice, "product doesnot exist!");
        }

        /// <summary>
        /// Tests if the order quantity is below or equal to the limit present in inventory.
        /// </summary>
        [TestMethod]
        public void QuantityLimit()
        {
            Inventory newInventory5 = new();
            newInventory5.InventoryCheck(2, "apple", 9, 4, "Store@123");
            
            Order newOrder5 = new();
            string invoice = newOrder5.PlaceOrder(2, "apple", 5, newInventory5);

            Assert.AreEqual(invoice, "only 4 quantity availible!");
        }

        /// <summary>
        /// Tests if the required quantity is more than 0.
        /// </summary>
        [TestMethod]
        public void OrderQuantityBound()
        {
            Inventory newInventory6 = new();
            newInventory6.InventoryCheck(2, "apple", 9, 4, "Store@123");

            Order newOrder6 = new();
            string invoice = newOrder6.PlaceOrder(2, "apple", -7, newInventory6);

            Assert.AreEqual(invoice, "set order quantity more than 0!");
        }

        /// <summary>
        /// Tests if the product quantity is updating in the inventory after multiple purchases.
        /// </summary>
        [TestMethod]
        public void MultipleOrderQuantityCheck()
        {
            Inventory newInventory8 = new();
            newInventory8.InventoryCheck(1, "mangoe", 12, 7, "Store@123");

            Order newOrder8_1 = new();
            newOrder8_1.PlaceOrder(1, "mangoe", 4, newInventory8);
            Order newOrder8_2 = new();
            string invoice = newOrder8_2.PlaceOrder(1, "mangoe", 5, newInventory8);

            Assert.AreEqual(invoice, "only 3 quantity availible!");
        }

        /// <summary>
        /// Tests if the employee is trying to set un-allowed price.
        /// </summary>
        [TestMethod]
        public void PriceAndQuantityCheck1()
        {
            Inventory newInventory9 = new();
            string inventoryInfo = newInventory9.InventoryCheck(1, "mangoe", -19, 7, "Store@123");

            Assert.AreEqual(inventoryInfo, "unacceptable quantity/price!");
        }

        /// <summary>
        /// Tests if the employee is trying to set un-allowed quantity.
        /// </summary>
        [TestMethod]
        public void PriceAndQuantityCheck2()
        {
            Inventory newInventory10 = new();
            string inventoryInfo = newInventory10.InventoryCheck(1, "mangoe", 8, -99, "Store@123");

            Assert.AreEqual(inventoryInfo, "unacceptable quantity/price!");
        }

        /// <summary>
        /// Tests if the employee is trying to set un-allowed price and quantity.
        /// </summary>
        [TestMethod]
        public void PriceAndQuantityCheck3()
        {
            Inventory newInventory11 = new();
            string inventoryInfo = newInventory11.InventoryCheck(1, "mangoe", -11, -9, "Store@123");

            Assert.AreEqual(inventoryInfo, "unacceptable quantity/price!");
        }

        /// <summary>
        /// Tests the security if a user is trying to edit inventory data.
        /// </summary>
        [TestMethod]
        public void InventoryAccessCheck()
        {
            Inventory newInventory12 = new();
            string inventoryInfo = newInventory12.InventoryCheck(3, "banana", 3, 24, "Password@123");

            Assert.AreEqual(inventoryInfo, "access denied!");
        }
    }
}
