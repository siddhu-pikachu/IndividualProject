/******************************************************************************
* Filename    = Payment.cs
*
* Author      = Rapeti Siddhu Neehal
*
* Product     = FacadeDesignPattern
* 
* Project     = ECommerse
*
* Description = Payment mechanism for the E-Commerse app.
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse
{
    /// <summary>
    /// This class will have the payment mechanism
    /// </summary>
    internal class Payment
    {
        // this is the variable used to serialise the paymentIds
        private readonly int _nextPaymentId = 1;
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }

        /// <summary>
        /// increments and sets the paymentIds every time the payment object is created
        /// </summary>
        /// <param name="paymentId"> the id of this payment</param>
        /// <param name="amount">the amount of the payment</param>
        public Payment(decimal amount)
        {
            PaymentId = _nextPaymentId++;
            Amount = amount;
            PaymentStatus = "pending";
        }

        /// <summary>
        /// the method to make payment.
        /// </summary>
        /// <returns>return the payment id</returns>
        public int MakePayment()
        {
            PaymentStatus = "processed";
            return PaymentId;
        }
    }
}
