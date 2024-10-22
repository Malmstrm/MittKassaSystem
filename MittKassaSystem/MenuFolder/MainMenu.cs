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
        public MainMenu()
        {
            string prompt = "Welcome";
            string[] options = { "Customer", "Product", "Exit" };
            _menuSystem = new MenuSystem(prompt, options);
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
                    Console.Clear();
                    Console.WriteLine("New Customer");
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Product Selected");
                    break;
                case 2:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
