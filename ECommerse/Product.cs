/******************************************************************************
* Filename    = Product.cs
*
* Author      = Rapeti Siddhu Neehal
*
* Product     = FacadeDesignPattern
* 
* Project     = ECommerse
*
* Description = Product and its details needed for the E-Commerse app.
*****************************************************************************/

using System;

namespace ECommerse
{
    /// <summary>
    /// Class representing a product in the e-commerce system
    /// </summary>
    public class Product
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// This initialises the product attributes after cverifying the password
        /// </summary>
        /// <param name="productId">The unique id associated with the product</param>
        /// <param name="name">the name of the product</param>
        /// <param name="price">price of the product</param>
        /// <param name="quantity">New property to store product quantity</param>
        /// <param name="password">The password needed to change the edit the details</param>
        public Product(int productId, string name, decimal price, int quantity, string password)
        {
            if( password == "Store@123")
            {
                ProductId = productId;
                Name = name;
                Price = price;
                Quantity = quantity;
            }
        }

        /// <summary>
        /// method to return the availioble quantity
        /// </summary>
        /// <returns>quantity of the product</returns>
        public int CheckAvailableQuantity()
        {
            return Quantity;
        }

        /// <summary>
        /// method to get the proce of the product
        /// </summary>
        /// <returns>price</returns>
        public decimal GetProductPrice()
        {
            return Price;
        }
    }
}