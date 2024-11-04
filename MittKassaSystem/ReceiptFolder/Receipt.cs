using MittKassaSystem.ProductFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.ReceiptFolder
{
    public class Receipt
    {
        public byte ReceiptNumber { get; set; }
        public List<Product> PurchasedProducts { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Change {  get; set; }
        public DateTime Date { get; set; }
        public Receipt(byte receiptNumber, List<Product> purchasedProducts, decimal totalAmount, decimal amountPaid)
        {
            ReceiptNumber = receiptNumber;
            PurchasedProducts = purchasedProducts;
            TotalAmount = totalAmount;
            AmountPaid = amountPaid;
            Change = amountPaid - totalAmount;
            Date = DateTime.Now;
        }
    }
}
