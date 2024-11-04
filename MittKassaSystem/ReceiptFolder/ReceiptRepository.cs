using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.ReceiptFolder
{
    public class ReceiptRepository
    {
        private readonly string filePathReceipt = "../../../Files/Receipt.csv";
        private readonly ReceiptNumberGenerator numberGenerator;

        public ReceiptRepository(ReceiptNumberGenerator numberGenerator)
        {
            this.numberGenerator = numberGenerator;
        }

        public void SaveReceipt(Receipt receipt)
        {
            Console.Clear();
            string products = string.Join(", ", receipt.PurchasedProducts.Select(r => r.Name));
            string receiptData = $"*** Receipt Details ***\n" +
                                 $"Receipt Number: {receipt.ReceiptNumber}\n" +
                                 $"Products: {products}\n" +
                                 $"Total Amount: {receipt.TotalAmount:C}\n" +
                                 $"Amount Paid: {receipt.AmountPaid:C}\n" +
                                 $"Change: {receipt.Change:C}\n" +
                                 $"Date: {receipt.Date}\n" +
                                 $"-------------------------\n";
            File.AppendAllText(filePathReceipt, receiptData);
        }
    }
}
