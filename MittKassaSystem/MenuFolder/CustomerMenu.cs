using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.MenuFolder
{
    public class CustomerMenu
    {
        private readonly MenuSystem _menuSystem;
        public CustomerMenu()
        {
            string prompt = "Customer";
            string[] options = { };

            _menuSystem = new MenuSystem(prompt, options);
        }
        public void Show()
        {
            bool keepRunning = true;  // Control when to exit the loop
            while (keepRunning)
            {
                int selectedIndex = _menuSystem.Run();
                keepRunning = UserChoice(selectedIndex);  // Control loop based on return value
            }
        }
        private bool UserChoice(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("Add to cart");
                    Console.ReadKey(true);
                    break;
                case 1:
                    Console.Clear();
                    return false;
            }
            return true;
        }

    }
}
