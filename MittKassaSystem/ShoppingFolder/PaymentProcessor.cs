using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.ShoppingFolder
{
    public class PaymentProcessor
    {
        public bool ProcessPayment(decimal totalAmount, decimal amountPaid)
        {
            if (amountPaid >= totalAmount)
            {
                return true;
            }
            Console.WriteLine("Insufficient amount paid, please try again.");
            return false;
        }
    }
}
