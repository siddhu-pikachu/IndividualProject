/******************************************************************************
* Filename    = Inventory.cs
*
* Author      = Rapeti Siddhu Neehal
*
* Product     = FacadeDesignPattern
* 
* Project     = ECommerse
*
* Description = Inventory maintanance for the E-Commerse app.
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse
{
    /// <summary>
    /// This is the first facade clqass created to simplify the inventory management for the staff.
    /// </summary>
    public class Inventory
    {

        // This is the set that stores all the product objects (list of the products)
        private readonly HashSet<Product> _productList = new();
        /// <summary>
        /// This checks if the product exists in the inventory and adds it if the caller has the correct password other wise say the product doesnot exist
        /// </summary>
        /// <param name="productId">the id of the product that we want to use</param>
        /// <param name="name">the name of the product that we want to use</param>
        /// <param name="price">the price of the product that we want to use</param>
        /// <param name="quantity">the quantity of the product that we want to use</param>
        /// <param name="password">the password for inevntory access</param>
        /// <returns></returns>
        public string InventoryCheck (int productId, string name, decimal price, int quantity, string password)
        {
            if (!_productList.Any(product => product.ProductId == productId))
            {
                // Product with the specified ID doesn't exist, so create and add it.
                Product newProduct = new (
                    productId,
                    name,
                    price,
                    quantity, 
                    password
                );
                if (password == "Store@123")
                {
                    if (quantity > 0 && price > 0)
                    {
                        _productList.Add(newProduct);
                        return "product added to inventory!";
                    }
                    else
                    {
                        return "unacceptable quantity/price!";
                    }
                }
                else
                {
                    return "access denied!";
                }
            }
            else
            {
                Product foundProduct = _productList.FirstOrDefault(product => product.ProductId == productId);
                if (foundProduct.Name != name) 
                {
                    return "different product is using the id " + foundProduct.ProductId + " already exists!";
                }
                else
                {
                    return "product exists!";
                }
            }
        }

        /// <summary>
        /// this finds the product object given its particular id and returns it.
        /// </summary>
        /// <param name="productId">the id of the product that we want to use</param>
        /// <returns></returns>
        public Product GetProducrFromInventory (int productId)
        {
            Product foundProduct = _productList.FirstOrDefault(product => product.ProductId == productId);
            return foundProduct;
        }

        /// <summary>
        /// This is the adjust the quantity after each order that has been placed.
        /// </summary>
        /// <param name="productId">the id of the product that we want to use</param>
        /// <param name="quantity">the quantity of the order placed</param>
        public void AdjustQuantity (int productId, int quantity)
        {
            Product foundProduct = _productList.FirstOrDefault(product => product.ProductId == productId);
            foundProduct.Quantity -=  quantity;
        }
    }
}
