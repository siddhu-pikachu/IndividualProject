/******************************************************************************
* Filename    = Order.cs
*
* Author      = Rapeti Siddhu Neehal
*
* Product     = FacadeDesignPattern
* 
* Project     = ECommerse
*
* Description = Ordering maintanance for the E-Commerse app.
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse
{
    /// <summary>
    /// This is the facade class that the client/user will use to place an order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The function to place order.
        /// </summary>
        /// <param name="productId">the id of the product that has to be purchased</param>
        /// <param name="name">the name of the product that has to be purchased</param>
        /// <param name="quantity">the quantity of the product that has to be purchased</param>
        /// <param name="newInventory">the inventory from which the product that has to be purchased</param>
        /// <returns></returns>
        public string PlaceOrder(int productId,string name, int quantity, Inventory newInventory)
        {
            string getInventoryDetail = newInventory.InventoryCheck(productId, name, 0, 0, "");
            if (getInventoryDetail != "product exists!"&& getInventoryDetail != "product added to inventory!")
            {
                if (getInventoryDetail == "access denied!")
                {
                    return "product doesnot exist!";
                }
                return getInventoryDetail;
            }
            Product foundProduct = newInventory.GetProducrFromInventory(productId);
            int foundProductQuantity = foundProduct.CheckAvailableQuantity();
            if (quantity < 0)
            {
                return "set order quantity more than 0!";
            }

            if (foundProductQuantity < quantity)
            {
                return "only " + foundProductQuantity + " quantity availible!";
            }

            Payment newPayment = new(quantity * foundProduct.GetProductPrice());
            int paymentId = newPayment.MakePayment();

            newInventory.AdjustQuantity(productId, quantity);

            string paymentSlip = "Payment completed!, " + quantity + " " + foundProduct.Name + " ordered for " + newPayment.Amount + ". Payment ID is " + paymentId + ".";
            return paymentSlip;

        }
    }
}
