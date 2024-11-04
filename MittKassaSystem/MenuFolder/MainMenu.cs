using MittKassaSystem.ProductFolder;
using MittKassaSystem.ReceiptFolder;
using MittKassaSystem.ShoppingFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.MenuFolder
{
    public class MainMenu
    {
        private List<Product> products;
        private readonly MenuSystem _menuSystem;
        private readonly ProductManager productManager;
        private readonly MenuProducts _menuProducts;
        private readonly ShoppingCart _shoppingCart;

        public MainMenu()
        {
            string prompt = 
                "Navigate through UpArrow, W and DownArrow, S." +
                "\nEnter choice through 'Enter'." +
                "\n-----------------------------";
            string[] options = 
                { "Customer", "Product", "Exit" };

            FileHandler file = new FileHandler();
            products = file.LoadProduct();

            ProductDisplay display = new ProductDisplay();
            ProductInput input = new ProductInput(products);

            ReceiptNumberGenerator numberGenerator = new ReceiptNumberGenerator();
            ReceiptRepository receiptRepository = new ReceiptRepository(numberGenerator);
            ReceiptDisplay receiptDisplay = new ReceiptDisplay();

            _menuSystem = new MenuSystem(prompt, options);

            productManager = new ProductManager(display, input, file, products);
            _menuProducts = new MenuProducts(products);
            _shoppingCart = new ShoppingCart(productManager, receiptRepository, receiptDisplay, numberGenerator, products);
        }
        public void Show()
        {
            while (true)
            {
                int selectedIndex = _menuSystem.Run();
                UserChoice(selectedIndex);
            }
        }
        private void UserChoice(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    _shoppingCart.AddToCartProcess();
                    break;
                case 1:
                    _menuProducts.Show();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
