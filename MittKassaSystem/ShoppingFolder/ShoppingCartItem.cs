using MittKassaSystem.ProductFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.ShoppingFolder
{
    public class ShoppingCartItem
    {
        public Product Product { get; set; }
        public byte Quantity { get; set; }
        public ShoppingCartItem(Product product, byte quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public decimal TotalPrice()
        {
            return Product.Price * Quantity;
        }
        public void DisplayCart()
        {
            Console.WriteLine($"ID: {Product.Id}, Name: {Product.Name}, Price: {Product.Price}, Quantity: {Quantity}, Total: {TotalPrice():C}");
        }
    }
}
