using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.ProductFolder
{
    public class ProductInput
    {
        private List<Product> products;
        public ProductInput(List<Product> products)
        {
            this.products = products;
        }
        public void SetProductList(List<Product> products)
        {
            this.products = products;
        }
        public byte GetNextID(List<Product> products)
        {
            byte nexID = 1;

            while (products.Any(p => p.Id == nexID))
                nexID++;

            return nexID;
        }
        public string SetName()
        {
            Console.Write("\nEnter name: ");
            return Console.ReadLine();
        }
        public decimal GetPrice()
        {
            decimal price;
            while (true)
            {
                Console.Write("Set price: ");
                if (decimal.TryParse(Console.ReadLine(), out price))
                    break;
                else
                    Console.WriteLine("Invalid input, enter valid input.");
            }
            return price;
        }
    }
}
