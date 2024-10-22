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
        private readonly MenuSystem _menuSystem;
        private readonly ProductManager productManager;
        private readonly MenuProducts _menuProducts;
        private readonly CustomerMenu _customerMenu;
        private readonly ShoppingCart _shoppingCart;
        public MainMenu()
        {
            string prompt = "Welcome";
            string[] options = { "Customer", "Product", "Exit" };

            ProductDisplay display = new ProductDisplay();
            ProductInput input = new ProductInput(new List<Product>()); // Tom lista till att börja med
            FileHandler file = new FileHandler();

            ReceiptNumberGenerator numberGenerator = new ReceiptNumberGenerator();
            ReceiptRepository receiptRepository = new ReceiptRepository(numberGenerator);
            ReceiptDisplay receiptDisplay = new ReceiptDisplay();

            _menuSystem = new MenuSystem(prompt, options);
            productManager = new ProductManager(display, input, file);
            _menuProducts = new MenuProducts();
            _customerMenu = new CustomerMenu();
            _shoppingCart = new ShoppingCart(productManager, receiptRepository, receiptDisplay, numberGenerator);

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
