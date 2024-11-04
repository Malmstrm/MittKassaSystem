using MittKassaSystem.MenuFolder;
using MittKassaSystem.ProductFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem
{
    public class App
    {
        public void Start()
        {
            MainMenu mainMenu = new MainMenu();
            Console.WriteLine("Welcome to KassaSystmet!\n");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
            mainMenu.Show();
        }
    }
}
