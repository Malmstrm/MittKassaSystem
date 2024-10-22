using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.ProductFolder
{
    public class ProductManager
    {
        private List<Product> products;
        private readonly ProductDisplay display;
        private readonly ProductInput input;
        private readonly FileHandler file;
        
        public ProductManager(ProductDisplay display, ProductInput input, FileHandler file)
        {
            this.display = display;
            this.input = input;
            this.file = file;

            products = file.LoadProduct();
            input = new ProductInput(products);
        }
        public List<Product> GetProducts()
        {
            return new List<Product>(products);
        }
        public void AddProduct()
        {
            while (true)
            {
                Console.Clear();
                display.DisplayAllProducts(products);

                byte newId = input.GetNextID(products);
                string name = input.SetName();
                decimal price = input.GetPrice();

                Product newProduct = new Product(newId, name, price);
                products.Add(newProduct);
                file.SaveProducts(products);

                Console.Clear();
                Console.WriteLine($"Product added\n" +
                $"ID: {newId}, Name: {name}, Price: {price}");
                Console.Write("\nDo you want to add another product? Y/N: ");
                if (Console.ReadLine().ToLower() == "n")
                {
                    break;
                }
            }
        }
        public void EditProduct()
        {
            Console.Clear();
            display.DisplayAllProducts(products);

            Console.WriteLine("\nLeave blank to keep current name & price.");
            Console.Write("\nEnter ID: ");
            if (byte.TryParse(Console.ReadLine(), out byte id))
            {
                Product edit = products.Find(p => p.Id == id);
                if (edit != null)
                {
                    Console.WriteLine($"\nCurrent name: {edit.Name} & price: {edit.Price:C}.");
                    Console.Write("Set new name: ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newName))
                    {
                        edit.Name = newName;
                    }
                    Console.Write("\nSet new price: ");
                    string newPriceInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newPriceInput) && decimal.TryParse(newPriceInput, out decimal newPrice))
                    {
                        edit.Price = newPrice;
                    }
                    Console.WriteLine("Product updated.");
                }
                else Console.WriteLine("Couldnt find ID");
            }
            else Console.WriteLine("Invalid ID, try again.");
        }
        public void DeleteProduct()
        {
            Console.Clear();
            display.DisplayAllProducts(products);

            Console.Write("\nEnter ID of product which you want to delete: ");
            if (byte.TryParse(Console.ReadLine(), out byte id))
            {
                Product delete = products.Find(p => p.Id == id);
                if (delete != null)
                {
                    Console.Write($"\nConfirmation to delete '{delete.Name}'? Y/N: ");
                    string confirmation = Console.ReadLine().ToLower();
                    if (confirmation == "y")
                    {
                        products.Remove(delete);
                        Console.WriteLine($"Product '{delete.Name}' has been deleted");
                    }
                    else Console.WriteLine("Deletion been cancelled.");
                }
                else Console.WriteLine($"Product with ID {id} does not exist.");
            }
            else Console.WriteLine("Invalid id, please try again.");
        }
    }
}
