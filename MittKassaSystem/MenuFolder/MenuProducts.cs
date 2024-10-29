using MittKassaSystem.ProductFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.MenuFolder
{
    public class MenuProducts
    {
        private readonly MenuSystem _menuSystem;
        private List<Product> products;
        private readonly ProductDisplay display;
        private readonly ProductInput input;
        private readonly FileHandler file;
        private readonly ProductManager productManager;
        public MenuProducts(List<Product> products)
        {
            string prompt = "Products";
            string[] options = { "Add", "Edit", "Delete", "Return" };
            _menuSystem = new MenuSystem(prompt, options);
            display = new ProductDisplay();
            input = new ProductInput(products);
            file = new FileHandler();
            productManager = new ProductManager(display, input, file, products);
        }
        public void Show()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                int selectedIndex = _menuSystem.Run();
                keepRunning = UserChoice(selectedIndex);
            }
        }
        private bool UserChoice(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    productManager.AddProduct();
                    break;
                case 1:
                    productManager.EditProduct();
                    break;
                case 2:
                    productManager.DeleteProduct();
                    break;
                case 3:
                    Console.WriteLine("Return");
                    return false;
            }
            return true;
        }
    }
}
