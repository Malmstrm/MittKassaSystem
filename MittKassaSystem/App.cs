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

            Console.WriteLine("Welcome to KassaSystemet 1.0\n");
            Console.WriteLine("Loading system.");
            Console.WriteLine("Loading files.");

            MainMenu mainMenu = new MainMenu();
            FileHandler file = new FileHandler();
            file.LoadProduct();
            mainMenu.Show();

        }
    }
}
