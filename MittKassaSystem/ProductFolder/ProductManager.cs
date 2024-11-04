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
        private ProductDisplay display;
        private ProductInput input;
        private FileHandler file;

        public ProductManager(ProductDisplay display, ProductInput input, FileHandler fileHandler, List<Product> products)
        {
            this.display = display;
            this.input = input;
            this.file = fileHandler;
            this.products = products;
        }
        public List<Product> GetProducts()
        {
            return new List<Product>(products);
        }
        public void AddProduct()
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
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey(true);

        }
        public void EditProduct()
        {
            Console.Clear();
            display.DisplayAllProducts(products);

            Console.WriteLine("\nLeave blank to keep current name & price.");
            Console.WriteLine("'Exit' to return to menu.");
            Console.Write("\nEnter ID: ");
            if (byte.TryParse(Console.ReadLine(), out byte id))
            {
                Product edit = products.Find(p => p.Id == id);
                if (edit != null)
                {
                    Console.WriteLine($"\nCurrent name: {edit.Name} & price: {edit.Price:C}.");
                    Console.Write("Set new name: ");
                    string newName = Console.ReadLine();

                    if (newName.ToLower() == "exit")
                    {
                        return;
                    }

                    if (!string.IsNullOrEmpty(newName))
                    {
                        edit.Name = newName;
                    }
                    else
                    {
                        Console.WriteLine("No new name entered. Keeping current name.");
                    }

                    Console.Write("Set new price: ");
                    string newPriceInput = Console.ReadLine();

                    if (newPriceInput.ToLower() == "exit")
                    {
                        return;
                    }

                    if (!string.IsNullOrEmpty(newPriceInput) && decimal.TryParse(newPriceInput, out decimal newPrice))
                    {
                        edit.Price = newPrice;
                        file.SaveProducts(products);
                    }
                    else
                    {
                        Console.WriteLine("No new price entered. Keeping current price.");
                    }
                    Console.WriteLine("Product updated.");
                }
                else
                {
                    Console.WriteLine("Couldnt find ID");
                    Console.ReadKey(true);
                }

            }
            else
            {
                Console.WriteLine("Invalid ID, try again.");
                Console.ReadKey(true);
            }
            
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
                        file.SaveProducts(products);
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
