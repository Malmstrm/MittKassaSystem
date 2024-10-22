using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.ReceiptFolder
{
    public class ReceiptDisplay
    {
        public void DisplayReceipt(Receipt receipt)
        {
            Console.WriteLine("\n*** Receipt Details ***");
            Console.WriteLine($"Receipt Number: {receipt.ReceiptNumber}");  // Använd det kvittonummer som redan finns i kvittot
            Console.WriteLine($"Date: {receipt.Date}");

            Console.WriteLine("Products:");
            foreach (var product in receipt.PurchasedProducts)
            {
                Console.WriteLine($"- {product.Name}");
            }
            Console.WriteLine($"Total Amount: {receipt.TotalAmount:C}");
            Console.WriteLine($"Amount Paid: {receipt.AmountPaid:C}");
            Console.WriteLine($"Change: {receipt.Change:C}");
            Console.WriteLine("-------------------------\n");

        }
    }
}
