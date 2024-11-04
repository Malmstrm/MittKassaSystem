using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.ProductFolder
{
    public class ProductDisplay
    {
        public void Display(Product product)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
        }
        public void DisplayAllProducts(List<Product> products)
        {
            if (products.Count == 0)
                Console.WriteLine("No availble products.");
            else
            {
                Console.WriteLine($"Availble products:\n");
                foreach (Product product in products)
                {
                    Display(product);
                }
            }
        }
    }
}
