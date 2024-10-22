using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.ProductFolder
{
    public class FileHandler
    {
        private readonly string filePathList = "../../../Files/Products.csv";
        public List<Product> LoadProduct()
        {
            var products = new List<Product>();
            if (File.Exists(filePathList))
            {
                var lines = File.ReadAllLines(filePathList);
                foreach (var line in lines)
                {
                    try
                    {
                        var parts = line.Split(",");
                        byte id = byte.Parse(parts[0].Split(":")[1].Trim());
                        string name = parts[1].Split(":")[1].Trim();
                        decimal price = decimal.Parse(parts[2].Split(":")[1].Trim());

                        Product newProduct = new Product(id, name, price);
                        products.Add(newProduct);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error reading line '{line}': {ex.Message}");
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey(true);
                    }
                }
            }
            if (products.Count == 0)
            {
                Console.WriteLine("No products was found, loading default list.");
                products = LoadDefaultProducts();
                SaveProducts(products);
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey(true);
            }
            return products;
        }
        public void SaveProducts(List<Product> products)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePathList))
                {
                    foreach (var product in products)
                    {
                        sw.WriteLine(product.ToCsv());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during save: {ex.Message}");
            }
        }
        private List<Product> LoadDefaultProducts()
        {
            return new List<Product>()
            {   
                new Product(1, "Basic Bow", 83),
                new Product(2, "Wooden Arrow", 7),
                new Product(3, "Basic Dagger", 45),
                new Product(4, "Wooden Sword", 53),
                new Product(5, "Tunic", 23)
            };
        }
    }
}
